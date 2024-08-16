using System;
using System.Collections.Generic;
using UnityEngine;

public enum EntityAction
{
    Move,
    Attack,
    PickObject,
    TransferItem,
    ChangeInventory,
    ReloadWeapon,
}

public class InventoryInfo
{
    public List<ItemTemplate> InventorySnapshot;
    public ItemTemplate MainWeaponTemplate;
    public ItemTemplate SecondaryWeaponTemplate;
    public ItemTemplate ShoulderWeaponTemplate;
}

public class InventoryStateInfo
{
    public InventoryInfo PrevState;
    public InventoryInfo CurrentState;
}

public class InventoryChangeInfo
{
    public InventoryStateInfo InventoryState;
    public ContainerSlot ChangedContainerSlot;
    public List<ItemTemplate> ContainerPrevStateInfo;
    public List<ItemTemplate> ContainerNextStateInfo;

    public InventoryChangeInfo()
    {
        InventoryState = new();
    }
}

public class TransferItemInfo
{
    public DropSlot Source {  get; private set; }
    public DropSlot Destination { get; private set; }
    public int SourceItemIndex {  get; private set; } 
    public ItemPresenter ItemPresenter { get; private set; }
    public ItemTemplate ItemTemplate { get; private set; }

    public TransferItemInfo(DropSlot source, DropSlot destination, ItemPresenter itemPresenter, ItemTemplate itemTemplate, int sourceItemIndex = 0)
    {
        Source = source;
        Destination = destination;
        ItemPresenter = itemPresenter;
        SourceItemIndex = sourceItemIndex;
        ItemTemplate = itemTemplate;
    }
}

public class ReloadWeaponInfo
{
    //public ItemPresenter WeaponPresenter { get; private set; }
    //public ItemPresenter AmmoPresenter { get; set; }
    //public Type AmmoType {  get; private set; }
    //public int AmmoUsed {  get; private set; }
    //public StorageSlot SourceSlot {  get; private set; }

    //public ReloadWeaponInfo(ItemPresenter weaponPresenter, ItemPresenter ammoPresenter, int ammoUsed, StorageSlot sourceSlot)
    //{
    //    WeaponPresenter = weaponPresenter;
    //    AmmoPresenter = ammoPresenter;
    //    AmmoType = ammoPresenter.Item.GetType();
    //    AmmoUsed = ammoUsed;
    //    SourceSlot = sourceSlot;
    //}

    public InventoryChangeInfo InventoryChangeInfo;

    public ReloadWeaponInfo(InventoryChangeInfo inventoryChangeInfo)
    {
        InventoryChangeInfo = inventoryChangeInfo;
    }
}

public class AttackInfo
{
    public FireMode FireMode { get; private set; }
    public Type AmmoType { get; private set; }
    public int AmmoCount {  get; private set; }
    public EntityAvatar Target {  get; private set; }

    public AttackInfo(FireMode fireMode, Type ammoType, int ammoCount, EntityAvatar target)
    {
        FireMode = fireMode;
        AmmoType = ammoType;
        AmmoCount = ammoCount;
        Target = target;
    }

}

public class Quant
{
    public EntityAction Action { get; private set; }
    public object Object {  get; private set; }

    public Vector3? LastPosition {  get; private set; }
    public Quaternion LastRotation { get; private set; }

    public Quant(EntityAction _action, object _object, Vector3? lastPosition, Quaternion lastRotation)
    {
        Action = _action;
        Object = _object;
        LastPosition = lastPosition;
        LastRotation = lastRotation;
    }

    public Vector3? GetPosition()
    {
        switch (Action) 
        { 
            case EntityAction.Move:
                {
                    return Object as Vector3?;
                }
            default: return null;
        }
    }
}

