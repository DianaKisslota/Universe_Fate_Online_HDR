using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Shot,
    Burst,
    LongBurst,
    Reload
}
public static class Global 
{
    public static int TestID {  get; set; }
    public static Character Character { get; private set; }

    public static string CurrentMapName = null;
    public static string CurrentSectorID = null;

    private static Dictionary<Type, GameObject> EntityPrefabs = new Dictionary<Type, GameObject>();
    private static Dictionary<Type, GameObject> ItemPrefabs = new Dictionary<Type, GameObject>();
    private static Dictionary<Type, GameObject> ContainerPrefabs = new Dictionary<Type, GameObject>();
    private static Dictionary<Type, Sprite> Icons = new Dictionary<Type, Sprite>();
    private static Dictionary<(Type, SoundType), AudioClip> Sounds = new Dictionary<(Type, SoundType), AudioClip>();
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

    public static AudioClip GetSoundFor(Type type, SoundType soundType)
    {
        Sounds.TryGetValue((type, soundType), out AudioClip sound);
        return sound;
    }
    public static GameObject NavPointPrefab { get; set; }
    public static GameObject TargetPrefab { get; set; }
    public static GameObject ItemPresenterPrefab { get; set; }
    public static GameObject ItemHighlighterPrefab { get; set; }
    public static GameObject ContainerHighlighterPrefab { get; set; }


    static Global()
    {
        EntityPrefabs.Add(typeof(Character), Resources.Load<GameObject>("EntityModels/Character/Character2"));
        EntityPrefabs.Add(typeof(FeralDog), Resources.Load<GameObject>("EntityModels/Wolf_Animated/Prefabs/Wolf"));
        EntityPrefabs.Add(typeof(Reptiloid), Resources.Load<GameObject>("EntityModels/Rake/Perfabs/Rake_A"));

        ItemPrefabs.Add(typeof(AK47), Resources.Load<GameObject>("WeaponModels/Modern Weapons Pack/Ak-47/Prefab/Ak-47"));
        ItemPrefabs.Add(typeof(PM), Resources.Load<GameObject>("WeaponModels/PM Makarov/Makarov (PM)/Makarov"));
        ItemPrefabs.Add(typeof(KitchenKnife), Resources.Load<GameObject>("WeaponModels/kitchen-knife/Knife_prefab"));

        ContainerPrefabs.Add(typeof(Cabinet), Resources.Load<GameObject>("OtherModels/Cabinet/Cabinet"));
        ContainerPrefabs.Add(typeof(BiohazzardCase), Resources.Load<GameObject>("OtherModels/BiohazzardCase/BiohazzardCase"));

        Icons.Add(typeof(AK47), Resources.Load<Sprite>("WeaponModels/Modern Weapons Pack/Ak-47/AK-47_icon"));
        Icons.Add(typeof(PM), Resources.Load<Sprite>("WeaponModels/PM Makarov/Makarov (PM)/pm_icon"));
        Icons.Add(typeof(KitchenKnife), Resources.Load<Sprite>("WeaponModels/kitchen-knife/KitchenKnife"));
        Icons.Add(typeof(DogMeat), Resources.Load<Sprite>("Icons/dogmeat"));
        Icons.Add(typeof(Ammo9x18mm), Resources.Load<Sprite>("Icons/Ammo9x18mm"));
        Icons.Add(typeof(Ammo545x39mm), Resources.Load<Sprite>("Icons/Ammo545x39mm"));
        Icons.Add(typeof(Ammo762x39mm), Resources.Load<Sprite>("Icons/Ammo762x39mm"));

        Sounds.Add((typeof(PM), SoundType.Shot), Resources.Load<AudioClip>("Sound/9x18 shot"));
        Sounds.Add((typeof(AK47), SoundType.Shot), Resources.Load<AudioClip>("Sound/762x39shot"));
        Sounds.Add((typeof(AK47), SoundType.Reload), Resources.Load<AudioClip>("Sound/AK_reload"));

        NavPointPrefab = Resources.Load<GameObject>("ControlPrefabs/Nav");
        TargetPrefab = Resources.Load<GameObject>("ControlPrefabs/Target");
        ItemPresenterPrefab = Resources.Load<GameObject>("Presenters/ItemPresenter");
        ItemHighlighterPrefab = Resources.Load<GameObject>("ItemHighLighter");
        ContainerHighlighterPrefab = Resources.Load<GameObject>("ContainerHighLighter");

        InitCharacter();
    }

    public static void InitCharacter()
    {
        Character = new Character();
        Character.Inventory.AddItem(new AK47());
        Character.Inventory.AddItem(new PM());
        Character.Inventory.AddItem(new KitchenKnife());

        Character.Inventory.AddItem(new Ammo9x18mm(), 50);
       // Character.Inventory.AddItem(new Ammo545x39mm(), 30);
        Character.Inventory.AddItem(new Ammo762x39mm(), 30);
    }
        
}
