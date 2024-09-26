using System;
using UnityEngine;

public static class ContainerFactory
{
    public static ContainerObject CreateContainer(Type containerType, bool isDark = false, Transform parent = null)
    {
        var container = Activator.CreateInstance(containerType) as Container;
        return CreateContainer(container, isDark, parent);
    }

    public static ContainerObject CreateContainer(Container container, bool isDark = false, Transform parent = null)
    {
        var modelPrefab = Global.GetPrefabForContainer(container.GetType());
        var model = GameObject.Instantiate<GameObject>(modelPrefab, parent);
        model.AddComponent<Rigidbody>();

        return CreateContainerForModel(container, model, isDark);
    }

    public static ContainerObject CreateContainerForModel(Container container, GameObject model, bool isDark = false)
    {
        var containerObject = model.AddComponent<ContainerObject>();
        GameObject highLighter = null;
        if (container is LootContainer)
            highLighter = GameObject.Instantiate<GameObject>(Global.ItemHighlighterPrefab);
        else
        {
            if (isDark)
                highLighter = GameObject.Instantiate<GameObject>(Global.ContainerHighlighterDarkPrefab);
            else
                highLighter = GameObject.Instantiate<GameObject>(Global.ContainerHighlighterPrefab);
        }

        highLighter.transform.SetParent(model.transform, false);
        highLighter.transform.localPosition = Vector3.zero;


        containerObject.Light = highLighter;
        containerObject.LightOff();
        containerObject.Container = container;

        return containerObject;
    }

}

