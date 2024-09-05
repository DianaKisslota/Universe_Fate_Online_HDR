using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StorageSlot : DropSlot
{
    [SerializeField] GameObject _itemsParent;

    private Storage _storage;

    public event Action<ItemPresenter, ItemPresenter, int, StorageSlot> WeaponReloaded;

    public Storage Storage
    {
        get { return _storage; }
        set { _storage = value; }
    }

    private void OnEnable()
    {
        RefreshStorageInfo();
        FillSlots();
    }

    public void OnWeaponReloaded(ItemPresenter weaponPresenter, ItemPresenter ammoPresenter, int num)
    {
        WeaponReloaded?.Invoke(weaponPresenter, ammoPresenter, num, this);
    }

    public virtual void FillSlots()
    {
        for (var i = 0; i < transform.childCount; i++)
        { 
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (StoragePosition position in _storage.Items)
        {
            var itemPresenter = ItemFactory.CreateItemPresenter(position, _itemsParent.transform);
        }
    }

    protected override bool ItemAccepted(ItemPresenter itemPresenter)
    {
        itemPresenter.StoragePosition = Storage.AddItem(itemPresenter.Item, itemPresenter.Count);
        return true;
    }

    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        if (itemPresenter?.Count > 0)
            base.DropProcess(itemPresenter);
    }

    public void InsertItem(ItemPresenter itemPresenter)
    {
       itemPresenter.StoragePosition = Storage.AddItem(itemPresenter.Item, itemPresenter.Count);
    }

    public override void OnItemLeave(Item item)
    {
        base.OnItemLeave(item);
    }

    public void RefreshStorageInfo()
    {
        Storage.RefreshStorageInfo();
    }
}
