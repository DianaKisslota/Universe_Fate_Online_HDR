using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StorageSlot : DropSlot
{
    [SerializeField] GameObject _itemsParent;

    private Storage _storage;
    //   private List<GameObject> _children = new List<GameObject>();

    public List<ItemTemplate> StorageInfo { get; set; } = new List<ItemTemplate>();

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
        //while (_children.Count > 0)
        //{
        //    var itemObject = _children[0];
        //    _children.Remove(itemObject);
        //    Destroy(itemObject);
        //}

        for (var i = 0; i < transform.childCount; i++)
        { 
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (StoragePosition position in _storage.Items)
        {
            var itemPresenter = ItemFactory.CreateItemPresenter(position, _itemsParent.transform);

         //   _children.Add(itemPresenter.gameObject);
        }
    }

    protected override bool ItemAccepted(ItemPresenter itemPresenter)
    {
        Storage.AddItem(itemPresenter.Item, itemPresenter.Count);
        return true;
    }

    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        base.DropProcess(itemPresenter);
        //_children.Add(itemPresenter.gameObject);
    }

    public void InsertItem(ItemPresenter itemPresenter)
    {
        itemPresenter.StoragePosition = Storage.AddItem(itemPresenter.Item, itemPresenter.Count);
       // _children.Add(itemPresenter.gameObject);
    }

    public override void OnItemLeave(Item item)
    {
        //var itemObject = _children.FirstOrDefault(x => x.TryGetComponent<ItemPresenter>(out var presenter) && presenter.Item == item);
        //if (itemObject != null)
        //{
        //    _children.Remove(itemObject);
        //}
        base.OnItemLeave(item);
    }

    public void RefreshStorageInfo()
    {
        StorageInfo = GetItemsSnapshot();
    }
    private List<ItemTemplate> GetItemsSnapshot()
    {
        var result = new List<ItemTemplate>();
        foreach (StoragePosition storagePosition in Storage.Items)
        {
            var template = storagePosition.Item.GetTemplate();
            template.ItemCount = storagePosition.Count;
            result.Add(template);
        }

        return result;
    }

    public void RestoreStorage(List<ItemTemplate> storageInfo)
    {
        Storage.Clear();
        foreach (var itemTemplate in storageInfo)
        {
            Storage.AddPosition(ItemFactory.CreateItem(itemTemplate));
        }

        RefreshStorageInfo();
    }
}
