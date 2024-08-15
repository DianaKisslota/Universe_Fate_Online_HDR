using System;
using Unity.VisualScripting;
using UnityEngine;

public static class ItemFactory
{
    public static ItemObject CreateItem(Type itemType, GameObject parent = null)
    {
        var item = Activator.CreateInstance(itemType) as Item;
        var itemObject = CreateItem(item, parent);

        return itemObject;
    }

    public static ItemObject CreateItem(Item item, GameObject parent = null)
    {
        var modelPrefab = Global.GetPrefabForItem(item.GetType());
        if (modelPrefab == null)
            return null;
        var model = GameObject.Instantiate<GameObject>(modelPrefab);
        var itemObject = model.AddComponent<ItemObject>();
        model.AddComponent<Rigidbody>();
        var highLighter = GameObject.Instantiate<GameObject>(Global.ItemHighlighterPrefab);
        highLighter.transform.SetParent(model.transform, false);
        highLighter.transform.localPosition = Vector3.zero;
        itemObject.Light = highLighter;
        itemObject.LightOff();
        itemObject.Item = item;

        return itemObject;
    }

    public static StoragePosition CreateItem(ItemTemplate itemTemplate)
    {
        if (itemTemplate == null) 
            return null;
        var item = Activator.CreateInstance(itemTemplate.ItemType) as Item;
        if (itemTemplate is RangeWeaponTemplate rangeweapontemplate)
        {
            (item as RangeWeapon).CurrentAmmoType = rangeweapontemplate.AmmoType;
            (item as RangeWeapon).Reload(rangeweapontemplate.AmmoType, rangeweapontemplate.AmmoCount);
        }
        var result = new StoragePosition(item, 100);
        result.Count = itemTemplate.ItemCount;
        return result;
    }

    public static ItemPresenter CreateItemPresenter(Type itemType, Transform parent = null)
    {
        var item = Activator.CreateInstance(itemType) as Item;
        return CreateItemPresenter(item, parent);
    }

    public static ItemPresenter CreateItemPresenter(Item item, Transform parent = null)
    {
        var presenterObject = GameObject.Instantiate<GameObject>(Global.ItemPresenterPrefab, parent);

        var presenter = presenterObject.GetComponent<ItemPresenter>();

        presenter.Icon = Global.GetIconFor(item.GetType());
        presenter.StoragePosition = new StoragePosition(item, 1);

        if (item is RangeWeapon)
        {
            presenter.AddComponent<ReloadSlot>();
        }

        presenter.TestID = ++Global.TestID;

        return presenter;
    }

    public static ItemPresenter CreateItemPresenter(StoragePosition storagePosition, Transform parent = null)
    {
        var presenterObject = GameObject.Instantiate<GameObject>(Global.ItemPresenterPrefab, parent);

        var presenter = presenterObject.GetComponent<ItemPresenter>();

        presenter.Icon = Global.GetIconFor(storagePosition.Item.GetType());
        presenter.StoragePosition = storagePosition;

        if (storagePosition.Item is RangeWeapon)
        {
            presenter.AddComponent<ReloadSlot>();
        }

        presenter.TestID = ++Global.TestID;
        return presenter;
    }

}

