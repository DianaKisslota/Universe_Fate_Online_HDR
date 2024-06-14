using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAvatar : EntityAvatar
{
    [SerializeField] Transform _weaponPoint;
    [SerializeField] Transform _weaponBackPoint;
    [SerializeField] Transform _weaponSidePoint;
    private List<Quant> _quants = new List<Quant>();
    private Character Character => Entity as Character;

    private Dictionary<Item, ItemObject> _itemObjects = new Dictionary<Item, ItemObject>();
    public List<Quant> Quants { get { return _quants; } }

    public event Action StartApplainQuants;
    public event Action EndApplainQuants;

    private bool _quantsApplaying = false;

    protected override void Init()
    {
        Character.OnEquip += OnEquip;
        Character.OnUnEquip += OnUnEquip;
    }

    private ItemObject GetItemObject(Item item)
    {
        ItemObject resultObject = null;
        if (_itemObjects.ContainsKey(item))
        {
            resultObject = _itemObjects[item];
        }
        else
        {
            resultObject = ItemFactory.CreateItem(item);
            _itemObjects.Add(item, resultObject);
        }

        return resultObject;
    }
    private void OnEquip(Item item, SlotType slotType) 
    { 
        var itemObject = GetItemObject(item);
        switch (slotType)
        {
            case SlotType.MainWeapon:
                {
                    _animator.ResetTrigger("Idle");
                    //_animator.ResetTrigger("RemoveWeapon");
                    //_animator.SetTrigger("RemoveWeapon");
                    itemObject.gameObject.transform.parent = _weaponPoint;
                    switch ((item as Weapon).WeaponType)
                    {
                        case WeaponType.Rifle:
                        case WeaponType.AssaultRifle:
                        case WeaponType.SMG:
                            _animator.SetInteger("HasWeapon", 2);
                            break;
                        case WeaponType.Pistol:
                            _animator.SetInteger("HasWeapon", 1);
                            break;
                        case WeaponType.Knife:
                            _animator.SetInteger("HasWeapon", 3);
                            break;

                    }
                    break; 
                }
            case SlotType.SecondaryWeapon:
                itemObject.gameObject.transform.parent = _weaponSidePoint;
                break;
            case SlotType.Shoulder:
                itemObject.gameObject.transform.parent = _weaponBackPoint;
                break;
        }
        itemObject.gameObject.transform.localPosition = Vector3.zero;
        itemObject.gameObject.transform.localRotation = Quaternion.identity;
        itemObject.Take();
    }
    private void OnUnEquip(Item item, SlotType slotType) 
    { 
        if (slotType == SlotType.MainWeapon)
        {
            var itemObject = GetItemObject(item);
            itemObject.gameObject.SetActive(false);
            _animator.SetInteger("HasWeapon", 0);
        }
    }

    public void TakeItem(ItemObject itemObject)
    {

        if (itemObject.Item is Weapon)
        {
            if ((itemObject.Item as Weapon).WeaponType == WeaponType.Rifle || (itemObject.Item as Weapon).WeaponType == WeaponType.AssaultRifle)
                itemObject.gameObject.transform.parent = _weaponBackPoint;
            else
                itemObject.gameObject.transform.parent = _weaponSidePoint;
            itemObject.gameObject.transform.localPosition = Vector3.zero;
            itemObject.gameObject.transform.localRotation = Quaternion.identity;
        }
        itemObject.Take();
    }

    public void AddQuant(EntityAction action, object _object, Vector3? lastPosition, Quaternion lastRotation)
    {
        _quants.Add(new Quant(action, _object, lastPosition, lastRotation));
    }

    public void AddMoveQuant(Vector3 point)
    {
        AddQuant(EntityAction.Move, point, transform.position, transform.rotation);
    }

    public void AddPickObjectQuant(ItemObject itemObject)
    {
        AddQuant(EntityAction.PickObject, itemObject, itemObject.transform.position, itemObject.transform.rotation);
    }

    public void AddItemtransferQuant(TransferItemInfo transferItemInfo)
    {
        AddQuant(EntityAction.TransferItem, transferItemInfo, transform.position, transform.rotation);
    }

    public void RemoveLastQuant()
    {
        if (_quants.Count > 0)
            _quants.RemoveAt(_quants.Count - 1);
    }

    public void RemoveAllQuants()
    {
        _quants.Clear();
    }

    private void StartCurrentQuant()
    {
        if (_quants.Count == 0)
            return;
        switch (_quants[0].Action)
        {
            case EntityAction.Move:
                MoveTo((_quants[0].Object as Vector3?).Value);
                break;
            case EntityAction.PickObject:
                TakeItem(_quants[0].Object as ItemObject);
                break;
            case EntityAction.TransferItem:
                {
                    var transferItemInfo = _quants[0].Object as TransferItemInfo;
                    var sourceSlot = transferItemInfo.Source;
                    var destinationSlot = transferItemInfo.Destination;
                    var item = transferItemInfo.Item;

                    TransferItem(sourceSlot, destinationSlot, item);
                }
                break;
                
            default:
                Debug.LogError("Неизвестный тип действия");
                break;
        }
    }

    public void SetToPosition(Vector3 position)
    {
        _agent.destination = position;
        _agent.enabled = false;
        transform.position = position;
        _walkingTo = null;
        _agent.enabled = true;
    }

    public void ApplyQuants()
    {
        if (_quants.Count == 0)
            return;
        StartApplainQuants?.Invoke();
        _quantsApplaying = true;
        StartCurrentQuant();
    }

    protected override void CheckWalking()
    {
        base.CheckWalking();
    }

    protected override void AdditionChecks()
    {  
        base.AdditionChecks();
        
        if ( _quantsApplaying)        
        {
            var quantEnded = false;
            switch (_quants[0].Action)
            {
                case EntityAction.Move:
                    {
                        quantEnded = _walkingTo == null;
                    }
                    break;
                case EntityAction.PickObject:
                    {
                        var itemObject = _quants[0].Object as ItemObject;
                        TakeItem(itemObject);
                        quantEnded = true;
                    }
                    break;
                case EntityAction.TransferItem:
                    {
                        quantEnded = true;
                        break;
                    }
                default:
                    Debug.LogError("Неизвестный тип действия");
                    break;
            }
            if (quantEnded)
            {
                _quants.RemoveAt(0);
                if (_quants.Count > 0)
                    StartCurrentQuant();
                else
                {
                    _quantsApplaying = false;
                    EndApplainQuants?.Invoke();
                }
            }
        }
    }

    public void TransferItem(DropSlot sourceSlot, DropSlot destinationSlot, Item item)
    {
        if (sourceSlot is CharacterItemSlot sourceItemSlot)
        {
            sourceItemSlot.Character.UnEquip(item, sourceItemSlot);
            sourceItemSlot.InitSlot(null);
        }
        if (destinationSlot is CharacterItemSlot destinationItemSlot)
        {
            destinationItemSlot.Character.Equip(item, destinationItemSlot);
            destinationItemSlot.InitSlot(item);

        }
        if (sourceSlot is StorageSlot sourceStorageSlotSlot)
        {
            sourceStorageSlotSlot.Storage.RemoveItem(item);
            sourceStorageSlotSlot.FillSlots();
        }
        if (destinationSlot is StorageSlot destinationStorageSlot)
        {
            destinationStorageSlot.Storage.AddItem(item);
            destinationStorageSlot.FillSlots();

        }
    }

}
