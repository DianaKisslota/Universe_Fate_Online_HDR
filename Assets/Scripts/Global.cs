using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global 
{
    public static Character Character { get; private set; }

    public static string CurrentMapName = null;
    public static string CurrentSectorID = null;

    private static Dictionary<Type, GameObject> EntityPrefabs = new Dictionary<Type, GameObject>();
    private static Dictionary<Type, GameObject> ItemPrefabs = new Dictionary<Type, GameObject>();
    private static Dictionary<Type, GameObject> ContainerPrefabs = new Dictionary<Type, GameObject>();
    private static Dictionary<Type, Sprite> Icons = new Dictionary<Type, Sprite>();
    public static GameObject GetPrefabForEntity(Type entityType)
    {
        EntityPrefabs.TryGetValue(entityType, out GameObject obj);
        return obj;
    }

    public static GameObject GetPrefabForItem(Type itemType)
    {
        ItemPrefabs.TryGetValue(itemType, out GameObject obj);
        return obj;
    }

    public static GameObject GetPrefabForContainer(Type containerType)
    {
        ContainerPrefabs.TryGetValue(containerType, out GameObject obj);
        return obj;
    }

    public static Sprite GetIconFor(Type type)
    {
        Icons.TryGetValue(type, out Sprite sprite);
        return sprite;
    }

    public static GameObject NavPointPrefab { get; set; }
    public static GameObject ItemPresenterPrefab { get; set; }
    public static GameObject ItemHighlighterPrefab { get; set; }
    public static GameObject ContainerHighlighterPrefab { get; set; }


    static Global()
    {
        EntityPrefabs.Add(typeof(FeralDog), Resources.Load<GameObject>("EntityModels/Wolf_Animated/Prefabs/Wolf"));
        EntityPrefabs.Add(typeof(Reptiloid), Resources.Load<GameObject>("EntityModels/Rake/Perfabs/Rake_A"));

        ItemPrefabs.Add(typeof(AK47), Resources.Load<GameObject>("WeaponModels/Modern Weapons Pack/Ak-47/Prefab/Ak-47"));
        ItemPrefabs.Add(typeof(PM), Resources.Load<GameObject>("WeaponModels/PM Makarov/Makarov (PM)/Makarov"));
        ItemPrefabs.Add(typeof(KitchenKnife), Resources.Load<GameObject>("WeaponModels/kitchen-knife/lp"));

        ContainerPrefabs.Add(typeof(Cabinet), Resources.Load<GameObject>("OtherModels/Cabinet/Cabinet"));
        ContainerPrefabs.Add(typeof(BiohazzardCase), Resources.Load<GameObject>("OtherModels/BiohazzardCase/BiohazzardCase"));

        Icons.Add(typeof(AK47), Resources.Load<Sprite>("WeaponModels/Modern Weapons Pack/Ak-47/AK-47_icon"));
        Icons.Add(typeof(PM), Resources.Load<Sprite>("WeaponModels/PM Makarov/Makarov (PM)/pm_icon"));
        Icons.Add(typeof(KitchenKnife), Resources.Load<Sprite>("WeaponModels/kitchen-knife/KitchenKnife"));
        Icons.Add(typeof(DogMeat), Resources.Load<Sprite>("Icons/dogmeat"));

        NavPointPrefab = Resources.Load<GameObject>("ControlPrefabs/Nav");
        ItemPresenterPrefab = Resources.Load<GameObject>("Presenters/ItemPresenter");
        ItemHighlighterPrefab = Resources.Load<GameObject>("ItemHighLighter");
        ContainerHighlighterPrefab = Resources.Load<GameObject>("ContainerHighLighter");

        InitCharacter();
    }

    public static void InitCharacter()
    {
        Character = new Character();
        Character.Inventory.AddItem(new PM());
        Character.Inventory.AddItem(new KitchenKnife());
    }
        
}
