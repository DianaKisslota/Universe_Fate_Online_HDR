using System;
using UnityEngine;

public static class ItemFactory
{
    public static ItemObject CreateItem(Type itemType, GameObject parent = null)
    {
        var modelPrefab = Global.GetPrefabForItem(itemType);
        var model = GameObject.Instantiate<GameObject>(modelPrefab);
        var itemObject = model.AddComponent<ItemObject>();
        model.AddComponent<Rigidbody>();
        //var light = model.AddComponent<Light>();
        //light.intensity = 10;
        //light.range = 2;
        //light.color = new Color(19, 87, 3);
        var item = Activator.CreateInstance(itemType) as Item;
        itemObject.Item = item;

        return itemObject;
    }

    public static ItemPresenter CreateItemPresenter(Type itemType, Transform parent = null)
    {
        var presenterObject = GameObject.Instantiate<GameObject>(Global.ItemPresenterPrefab, parent);

        var presenter = presenterObject.GetComponent<ItemPresenter>();

        presenter.Icon = Global.GetIconFor(itemType);
        presenter.Item = Activator.CreateInstance(itemType) as Item;
        presenter.Count = 1;

        return presenter;
    }
}

