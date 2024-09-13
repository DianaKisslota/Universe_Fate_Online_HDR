using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAvatar : EntityAvatar
{
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private Transform _weaponBackPoint;
    [SerializeField] private Transform _weaponSidePoint;
    public CharacterInventoryPresenter InventoryPresenter { get; set; }
    public ContainerPresenter ContainerPresenter { get; set; }

    private List<Quant> _quants = new List<Quant>();
    public Character Character => Entity as Character;

    public Dictionary<Item, ItemObject> ItemObjects = new Dictionary<Item, ItemObject>();

    private InventoryInfo _inventoryInfo = new InventoryInfo();
    public InventoryInfo InventoryInfo => _inventoryInfo;
    public List<Quant> Quants { get { return _quants; } }

    public event Action StartApplainQuants;
    public event Action EndApplainQuants;
    public event Action<FireMode> FireModeSet;
    public event Action<DropSlot, DropSlot, ItemPresenter> ItemPresenterTransferred;
    public event Action<Item> MainWeaponChanged;

    private bool _quantsApplaying = false;

    private float _isWalking = 0f;
    private float _isAttacking = 0f;
    private float _isReloading = 0f;
    private float _animationCooldown = 0f;

    public FireMode FireMode { get; set; }

    protected override AudioClip _rangeAttackSound
    {
        get
        {
            if (Character.MainWeapon != null)
                return Global.GetSoundFor(Character.MainWeapon.GetType(), SoundType.Shot);
            else
                return null;
        }
    }

    protected override void Init()
    {
        base.Init();
        RefreshInventoryInfo();
        Character.OnEquip += OnEquip;
        Character.OnUnEquip += OnUnEquip;
    }

    private void OnDestroy()
    {
        Character.OnEquip -= OnEquip;
        Character.OnUnEquip -= OnUnEquip;
    }

    public ItemObject GetItemObject(Item item)
    {
        ItemObject resultObject = null;
        if (ItemObjects.ContainsKey(item))
        {
            resultObject = ItemObjects[item];
        }
        else
        {
            resultObject = ItemFactory.CreateItem(item);
            ItemObjects.Add(item, resultObject);
        }

        return resultObject;
    }

    private void ClearItemObjects()
    {
        foreach (var item in ItemObjects) 
        {
            if (ItemObjects.TryGetValue(item.Key, out var itemObject))
            {
                if (itemObject != null && itemObject.transform.parent != null)
                    Destroy(itemObject.gameObject);
            }
        }
        ItemObjects.Clear();   
    }
    private void OnEquip(Item item, SlotType slotType)
    {
        ReflectEquipment(item, slotType);

        InventoryPresenter.InitItemSlots();
    }

    public void RefreshInventoryInfo()
    {
        _inventoryInfo = new InventoryInfo()
        {
            MainWeaponTemplate = Character.MainWeapon == null ? null : Character.MainWeapon.GetTemplate(),
            SecondaryWeaponTemplate = Character.SecondaryWeapon == null ? null : Character.SecondaryWeapon.GetTemplate(),
            ShoulderWeaponTemplate = Character.ShoulderWeapon == null ? null : Character.ShoulderWeapon.GetTemplate(),
            InventorySnapshot = new List<ItemTemplate>()
        };

        foreach (StoragePosition storagePosition in Character.Inventory.Items) 
        {
            var template = storagePosition.Item.GetTemplate();
            template.ItemCount = storagePosition.Count;
            _inventoryInfo.InventorySnapshot.Add(template);
        }
    }
    public void ReflectAllItems()
    {
        ReflectEquipment(Character.MainWeapon, SlotType.MainWeapon);
        ReflectEquipment(Character.SecondaryWeapon, SlotType.SecondaryWeapon);
        ReflectEquipment(Character.ShoulderWeapon, SlotType.Shoulder);
    }

    public void ReflectEquipment(Item item, SlotType slotType)
    {
        if (item == null)
        {
            if (slotType == SlotType.MainWeapon)
                MainWeaponChanged?.Invoke(item);
            return;
        }
        var itemObject = GetItemObject(item);
        Quaternion rotation = Quaternion.identity;
        Vector3 position = Vector3.zero;
        if (slotType == SlotType.MainWeapon)
        {
            if (item is RangeWeapon rangeWeapon)
            {
                FireMode = rangeWeapon.GetLowerFireMode();
            }
            else
                FireMode = FireMode.Undefined;
            FireModeSet?.Invoke(FireMode);
            MainWeaponChanged?.Invoke(item);
        }

        switch (slotType)
        {
            case SlotType.MainWeapon:
                {
                    Animator.ResetTrigger("Idle");
                    itemObject.gameObject.transform.parent = _weaponPoint;
                    switch ((item as Weapon).WeaponType)
                    {
                        case WeaponType.Rifle:
                        case WeaponType.AssaultRifle:
                        case WeaponType.SMG:
                            Animator.SetInteger("HasWeapon", 2);
                            break;
                        case WeaponType.Pistol:
                            Animator.SetInteger("HasWeapon", 1);
                            break;
                        case WeaponType.Knife:
                            {
                                Animator.SetInteger("HasWeapon", 3);
                                rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                            }
                            break;
                    }
                    break;
                }
            case SlotType.SecondaryWeapon:
                {
                    if ((item as Weapon).WeaponType == WeaponType.Knife)
                    {
                        rotation = Quaternion.Euler(new Vector3(90, 90, 0));
                        position = new Vector3(0, -0.1f, -0.25f);
                    }
                    itemObject.gameObject.transform.parent = _weaponSidePoint;
                }
                break;
            case SlotType.Shoulder:
                itemObject.gameObject.transform.parent = _weaponBackPoint;
                break;
            default: return;
        }
        itemObject.gameObject.transform.localPosition = position;
        itemObject.gameObject.transform.localRotation = rotation;
        itemObject.gameObject.SetActive(true);
        itemObject.Take();
    }

    private void OnUnEquip(Item item, SlotType slotType)
    {
        if (ItemObjects.TryGetValue(item, out var itemObject))
        {
            Destroy(itemObject.gameObject);
            ItemObjects.Remove(item);
        }
        if (slotType == SlotType.MainWeapon)
        {
            Animator.SetInteger("HasWeapon", 0);
        }
    }

    public void TakeItem(ItemObject itemObject)
    {
        if (!ItemObjects.ContainsKey(itemObject.Item))
            ItemObjects.Add(itemObject.Item, itemObject);
        if (itemObject.Item is Weapon weapon)
        {
            if (Character.MainWeapon == null)
            {
                Character.Equip(weapon, SlotType.MainWeapon);
                MainWeaponChanged?.Invoke(weapon);
            }
            else
            {
                if (weapon.WeaponType == WeaponType.Rifle || weapon.WeaponType == WeaponType.AssaultRifle)
                {
                    if (Character.ShoulderWeapon == null)
                    {
                        Character.Equip(weapon, SlotType.Shoulder);
                    }
                    else
                    {
                        Character.Inventory.AddItem(weapon);
                        itemObject.Take();
                        itemObject.gameObject.SetActive(false);
                    }
                }
                else
                {
                    if (Character.SecondaryWeapon == null)
                    {
                        Character.Equip(weapon, SlotType.SecondaryWeapon);
                    }
                    else
                    {
                        Character.Inventory.AddItem(weapon);
                        itemObject.Take();
                        itemObject.gameObject.SetActive(false);
                    }
                }
            }
            ReflectAllItems();
        }
    }
    public void AddQuant(EntityAction action, object _object, Vector3? lastPosition, Quaternion lastRotation)
    {
        _quants.Add(new Quant(action, _object, lastPosition, lastRotation));
    }

    public void AddMoveQuant(Vector3 point)
    {
        AddQuant(EntityAction.Move, point, transform.position, transform.rotation);
    }

    public void AddPickObjectQuant(PickObjectInfo pickObjectInfo)
    {
        AddQuant(EntityAction.PickObject, pickObjectInfo, transform.position, transform.rotation);
    }

    public void AddItemtransferQuant(TransferItemInfo transferItemInfo)
    {
        AddQuant(EntityAction.TransferItem, transferItemInfo, transform.position, transform.rotation);
    }

    public void AddInventoryChangeQuant(InventoryChangeInfo inventoryStateInfo)
    {
        AddQuant(EntityAction.ChangeInventory, inventoryStateInfo, transform.position, transform.rotation);
    }

    public void AddReloadWeaponQuant(ReloadWeaponInfo reloadWeaponInfo)
    {
        AddQuant(EntityAction.ReloadWeapon, reloadWeaponInfo, transform.position, transform.rotation);
    }

    public void AddAttackQuant(AttackInfo attackInfo)
    {
        AddQuant(EntityAction.Attack, attackInfo, transform.position, transform.rotation);
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

    public void LookForShoot(EntityAvatar avatar)
    {
        var type = Character.MainWeapon?.WeaponType;
        transform.LookAt(avatar.transform);
        if (type == WeaponType.SMG || type == WeaponType.Rifle || type == WeaponType.AssaultRifle || type == WeaponType.MG)
            transform.Rotate(0, 55, 0);
    }

    public void RestoreInventory(InventoryInfo inventoryInfo, Container container = null, List<ItemTemplate> containerStorage = null,
        ContainerSlot changedContainerSlot = null)
    {
        ClearItemObjects();
        InventoryPresenter.ClearItemSlots();

        var mainWeaponPosition = ItemFactory.CreateItem(inventoryInfo.MainWeaponTemplate);
        Character.Equip(mainWeaponPosition == null? null : mainWeaponPosition.Item as Weapon, SlotType.MainWeapon);
        var secondaryWeaponPosition = ItemFactory.CreateItem(inventoryInfo.SecondaryWeaponTemplate);
        Character.Equip(secondaryWeaponPosition == null ? null : secondaryWeaponPosition.Item as Weapon, SlotType.SecondaryWeapon);
        var shoulderWeaponPosition = ItemFactory.CreateItem(inventoryInfo.ShoulderWeaponTemplate);
        Character.Equip(shoulderWeaponPosition == null ? null : shoulderWeaponPosition.Item as Weapon, SlotType.Shoulder);

        Character.Inventory.Clear();
        foreach(var itemTemplate in inventoryInfo.InventorySnapshot)
        {
            Character.Inventory.AddPosition(ItemFactory.CreateItem(itemTemplate));
        }

        InventoryPresenter.InitItemSlots();
        
        if (InventoryPresenter.gameObject.activeSelf)
            InventoryPresenter.Inventory.FillSlots();

        ReflectAllItems();

        RefreshInventoryInfo();

        if (container != null)
        {
            container.RestoreStorage(containerStorage);
            ContainerPresenter.Slot.FillSlots();
        }
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
                var pickObjectInfo = _quants[0].Object as PickObjectInfo;
                //RestoreInventory(pickObjectInfo.InventoryStateInfo.PrevState);
                //var pickedItem = ItemFactory.CreateItem(pickObjectInfo.ItemTemplate);
                //TakeItem(GetItemObject(pickedItem.Item));
                TakeItem(pickObjectInfo.PickedItemObject);
                break;
            //case EntityAction.TransferItem:
            //    {
            //        var transferItemInfo = _quants[0].Object as TransferItemInfo;
            //        var sourceSlot = transferItemInfo.Source;
            //        var destinationSlot = transferItemInfo.Destination;
            //        var item = transferItemInfo.ItemPresenter;

            //        TransferItem(sourceSlot, destinationSlot, item);

            //    }
            //    break;
            case EntityAction.ChangeInventory:
                {
                    var stateInventoryInfo = _quants[0].Object as InventoryChangeInfo;
                    RestoreInventory(stateInventoryInfo.InventoryState.CurrentState, stateInventoryInfo.ChangedContainer?.Container,
                                            stateInventoryInfo.ContainerNextStateInfo);

                }
                break;
            case EntityAction.ReloadWeapon:
                {
                    var reloadWeaponInfo = _quants[0].Object as ReloadWeaponInfo;
                    //var sourceSlot = reloadWeaponInfo.SourceSlot;
                    //var ammoPresenter = reloadWeaponInfo.AmmoPresenter;
                    //var ammoUsed = reloadWeaponInfo.AmmoUsed;
                    //var weaponPresenter = reloadWeaponInfo.WeaponPresenter;
                    //var weapon = weaponPresenter.Item as RangeWeapon;
                    //weapon.Reload(ammoPresenter.Item as Ammo, ammoUsed);
                    //weaponPresenter.RefreshInfo();
                    //ammoPresenter.Count -= ammoUsed;
                    //sourceSlot.FillSlots();
                    //if (weapon.WeaponType != WeaponType.Pistol)

                    RestoreInventory(reloadWeaponInfo.InventoryChangeInfo.InventoryState.CurrentState, 
                                            reloadWeaponInfo.InventoryChangeInfo.ChangedContainer?.Container,
                                            reloadWeaponInfo.InventoryChangeInfo.ContainerNextStateInfo);
                    PlaySound(Global.GetSoundFor(typeof(AK47), SoundType.Reload));
                    _isReloading = 0.5f;
                }
                break;
            case EntityAction.Attack:
                {
                    var attackInfo = _quants[0].Object as AttackInfo;
                    var target = attackInfo.Target;
                    if (Character.MainWeapon is RangeWeapon rangeWeapon)
                    {
                        LookForShoot(target);
                        var rangeAttackData = new RangeAttackData();
                        rangeAttackData.Target = target;
                        rangeAttackData.AmmoType = attackInfo.AmmoType;
                        rangeAttackData.ShotNumber = rangeWeapon.GetFireModeAmmo(attackInfo.FireMode).Value;
                        rangeAttackData.PossibleShotNumber = Mathf.Min(rangeAttackData.ShotNumber, rangeWeapon.AmmoCount);
                        rangeAttackData.WeaponType = rangeWeapon.GetType();

                        rangeWeapon.UnLoad(rangeAttackData.PossibleShotNumber);

                        RangeAttack(rangeAttackData);

                        InventoryPresenter.RefreshItemSlots();
                    }
                    else
                    {
                        var meleeAttackData = new MeleeAttackData();
                        meleeAttackData.Target = target;
                        meleeAttackData.BaseDamage = Character.BaseMeleeDamage;
                        meleeAttackData.BaseHitChance = Character.BaseHitChance;

                        MeleeAttack(meleeAttackData);

                        InventoryPresenter.RefreshItemSlots();
                    }
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

        if (_quantsApplaying)
        {
            var quantEnded = false;
            switch (_quants[0].Action)
            {
                case EntityAction.Move:
                    {
                        if (_walkingTo != null)
                            _isWalking = 0.4f;
                        _isWalking -= Time.deltaTime;
                         quantEnded = _isWalking <= 0;

                    }
                    break;
                case EntityAction.PickObject:
                    {
                        quantEnded = true;
                        break;
                    }
                //case EntityAction.TransferItem:
                //    {
                //        quantEnded = true;
                //        break;
                //    }
                case EntityAction.ChangeInventory:
                    {
                        quantEnded = true;
                        break;
                    }
                case EntityAction.ReloadWeapon:
                    {
                        _isReloading -= Time.deltaTime;
                        quantEnded = _isReloading <= 0;
                        break;
                    }
                case EntityAction.Attack:
                    {
                        if (_isAttacking > 0 && _isAttacking - Time.deltaTime <= 0)
                            _animationCooldown = 1f;

                         _isAttacking -= Time.deltaTime;
                        _animationCooldown -= Time.deltaTime;
                        quantEnded = _isAttacking <= 0 && _animationCooldown <= 0;
                        if (_isAttacking <= 0)
                            Animator.SetTrigger("Idle");
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

    //public void TransferItem(DropSlot sourceSlot, DropSlot destinationSlot, ItemPresenter itemPresenter)
    //{
    //    itemPresenter.SetToParent(destinationSlot.transform);
    //    if (sourceSlot is CharacterItemSlot sourceItemSlot)
    //    {
    //        sourceSlot.OnItemLeave(itemPresenter.Item);
    //        sourceItemSlot.Character.UnEquip(itemPresenter.Item);
    //    }
    //    if (destinationSlot is CharacterItemSlot destinationItemSlot)
    //    {
    //        destinationItemSlot.PresenterSet(itemPresenter);
    //        destinationItemSlot.Character.Equip(itemPresenter.Item, destinationItemSlot);
    //    }
    //    if (sourceSlot is StorageSlot sourceStorageSlotSlot)
    //    {
    //        sourceStorageSlotSlot.Storage.RemoveItem(itemPresenter.Item);
    //    }
    //    if (destinationSlot is StorageSlot destinationStorageSlot)
    //    {
    //        destinationStorageSlot.Storage.AddItem(itemPresenter.Item);

    //    }
    //    ItemPresenterTransferred?.Invoke(sourceSlot, destinationSlot, itemPresenter);
    //    //destinationSlot.OnItemSet(itemPresenter.Item, destinationSlot);
    //}

    protected override void RangeAttack(RangeAttackData attackData)
    {
        Animator.SetTrigger("Shoot");
        _isAttacking = attackData.PossibleShotNumber / 4f;

        var soundFire = Global.GetSoundFor(attackData.WeaponType, SoundType.Shot);
        var soundFailFire = Global.GetSoundFor(attackData.WeaponType, SoundType.FailShot);

        if (soundFire != null)
            PlaySound(soundFire, 0.1f, attackData.PossibleShotNumber);

        if (attackData.PossibleShotNumber == 0 && soundFailFire != null)
            PlaySound(soundFailFire);

        _isAttacking = 1f;

        var attackResolver = new AttackResolver();

        var attackResult = attackResolver.ResolveRangeAttack(Character, attackData.Target.Entity, attackData.PossibleShotNumber);

        attackData.Target.Entity.CurrentHealth -= attackResult.DamageInflicted;
    }

    protected override void MeleeAttack(MeleeAttackData attackData)
    {
        if (Vector3.Distance(attackData.Target.transform.position, transform.position) > 1.6f)
        {
            Debug.Log("Цель слишком далеко");
            _isAttacking = 0.5f;
            return;
        }
        transform.LookAt(attackData.Target.transform);
        AudioClip sound;
        if (Character.MainWeapon != null)
            sound = Global.GetSoundFor(Character.MainWeapon.GetType(), SoundType.MeleeStrike);
        else
            sound = Global.GetSoundFor(Character.GetType(), SoundType.BareHandStrike);

        Animator.SetTrigger("Melee");
        PlaySound(sound, 0.5f);

        _isAttacking = 0.5f;
        var attackResolver = new AttackResolver();
        var attackResult = attackResolver.ResolveMeleeAttack(Character, attackData.Target.Entity);
        attackData.Target.Entity.CurrentHealth -= attackResult.DamageInflicted;
    }

}
