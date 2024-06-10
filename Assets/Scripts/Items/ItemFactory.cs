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
        var highLighter = GameObject.Instantiate<GameObject>(Global.ItemHighlighterPrefab);
        highLighter.transform.SetParent(model.transform, false);
        highLighter.transform.localPosition = Vector3.zero;
        itemObject.Light = highLighter;
        itemObject.LightOff();
        var item = Activator.CreateInstance(itemType) as Item;
        itemObject.Item = item;

        return itemObject;
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
        presenter.Item = item;
        presenter.Count = 1;
        presenter.Name = item.Name;

        return presenter;
    }
}

