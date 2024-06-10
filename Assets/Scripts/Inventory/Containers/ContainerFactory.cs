using System;
using UnityEngine;

public static class ContainerFactory
{
    public static ContainerObject CreateContainer(Type containerType, Transform parent = null)
    {
        var modelPrefab = Global.GetPrefabForContainer(containerType);
        var model = GameObject.Instantiate<GameObject>(modelPrefab, parent);
        var containerObject = model.AddComponent<ContainerObject>();
        model.AddComponent<Rigidbody>();
        var highLighter = GameObject.Instantiate<GameObject>(Global.ContainerHighlighterPrefab);
        highLighter.transform.SetParent(model.transform, false);
        highLighter.transform.localPosition = Vector3.zero;
        containerObject.Light = highLighter;
        containerObject.LightOff();
        var container = Activator.CreateInstance(containerType) as Container;
        containerObject.Container = container;

        return containerObject;
    }

    public static ContainerObject CreateContainer(Container container, Transform parent = null)
    {
        var modelPrefab = Global.GetPrefabForContainer(container.GetType());
        var model = GameObject.Instantiate<GameObject>(modelPrefab, parent);
        var containerObject = model.AddComponent<ContainerObject>();
        model.AddComponent<Rigidbody>();
        var highLighter = GameObject.Instantiate<GameObject>(Global.ContainerHighlighterPrefab);
        highLighter.transform.SetParent(model.transform, false);
        highLighter.transform.localPosition = Vector3.zero;
        containerObject.Light = highLighter;
        containerObject.LightOff();
        containerObject.Container = container;

        return containerObject;
    }

}

