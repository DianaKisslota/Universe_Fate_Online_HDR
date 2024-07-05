﻿using System;
using UnityEngine;

public static class ContainerFactory
{
    public static ContainerObject CreateContainer(Type containerType, Transform parent = null)
    {
        var container = Activator.CreateInstance(containerType) as Container;
        return CreateContainer(container, parent);
    }

    public static ContainerObject CreateContainer(Container container, Transform parent = null)
    {
        var modelPrefab = Global.GetPrefabForContainer(container.GetType());
        var model = GameObject.Instantiate<GameObject>(modelPrefab, parent);
        model.AddComponent<Rigidbody>();

        return CreateContainerForModel(container, model);
    }

    public static ContainerObject CreateContainerForModel(Container container, GameObject model)
    {
        var containerObject = model.AddComponent<ContainerObject>();
        GameObject highLighter = null;
        if (container is LootContainer)
            highLighter = GameObject.Instantiate<GameObject>(Global.ItemHighlighterPrefab);
        else
            highLighter = GameObject.Instantiate<GameObject>(Global.ContainerHighlighterPrefab);

        highLighter.transform.SetParent(model.transform, false);
        highLighter.transform.localPosition = Vector3.zero;
        containerObject.Light = highLighter;
        containerObject.LightOff();
        containerObject.Container = container;

        return containerObject;
    }

}

