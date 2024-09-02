using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Shot,
    Burst,
    LongBurst,
    Reload,
    FailShot,
    MeleeStrike,
    BareHandStrike
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
        EntityPrefabs.Add(typeof(Kobold), Resources.Load<GameObject>("EntityModels/Rapax/Prefabs/Rapax_Green"));

        ItemPrefabs.Add(typeof(AK47), Resources.Load<GameObject>("WeaponModels/Modern Weapons Pack/Ak-47/Prefab/Ak-47"));
        ItemPrefabs.Add(typeof(PM), Resources.Load<GameObject>("WeaponModels/PM Makarov/Makarov (PM)/Makarov"));
        ItemPrefabs.Add(typeof(KitchenKnife), Resources.Load<GameObject>("WeaponModels/kitchen-knife/Knife_prefab"));
        ItemPrefabs.Add(typeof(UMP45), Resources.Load<GameObject>("WeaponModels/Modern Weapons Pack/UMP-45/Prefab/UMP-45"));

        ContainerPrefabs.Add(typeof(Cabinet), Resources.Load<GameObject>("OtherModels/Cabinet/Cabinet"));
        ContainerPrefabs.Add(typeof(BiohazzardCase), Resources.Load<GameObject>("OtherModels/BiohazzardCase/BiohazzardCase"));

        Icons.Add(typeof(AK47), Resources.Load<Sprite>("WeaponModels/Modern Weapons Pack/Ak-47/AK-47_icon"));
        Icons.Add(typeof(PM), Resources.Load<Sprite>("WeaponModels/PM Makarov/Makarov (PM)/pm_icon"));
        Icons.Add(typeof(KitchenKnife), Resources.Load<Sprite>("WeaponModels/kitchen-knife/KitchenKnife"));
        Icons.Add(typeof(UMP45), Resources.Load<Sprite>("WeaponModels/Modern Weapons Pack/UMP-45/UMP45Icon"));
        Icons.Add(typeof(DogMeat), Resources.Load<Sprite>("Icons/dogmeat"));
        Icons.Add(typeof(Ammo9x18mm), Resources.Load<Sprite>("Icons/Ammo9x18mm"));
        Icons.Add(typeof(Ammo545x39mm), Resources.Load<Sprite>("Icons/Ammo545x39mm"));
        Icons.Add(typeof(Ammo762x39mm), Resources.Load<Sprite>("Icons/Ammo762x39mm"));
        Icons.Add(typeof(Ammo045ACP), Resources.Load<Sprite>("Icons/Ammo045ACP"));
        Icons.Add(typeof(MetalScrap), Resources.Load<Sprite>("Icons/MetalScrap"));


        Sounds.Add((typeof(PM), SoundType.Shot), Resources.Load<AudioClip>("Sound/9x18 shot"));
        Sounds.Add((typeof(PM), SoundType.Reload), Resources.Load<AudioClip>("Sound/PM_Reload"));
        Sounds.Add((typeof(PM), SoundType.FailShot), Resources.Load<AudioClip>("Sound/Pistol_Fail"));
        Sounds.Add((typeof(AK47), SoundType.Shot), Resources.Load<AudioClip>("Sound/762x39shot"));
        Sounds.Add((typeof(AK47), SoundType.Reload), Resources.Load<AudioClip>("Sound/AK_reload"));
        Sounds.Add((typeof(AK47), SoundType.FailShot), Resources.Load<AudioClip>("Sound/AK_Fail"));
        Sounds.Add((typeof(UMP45), SoundType.Shot), Resources.Load<AudioClip>("Sound/762x39shot"));
        Sounds.Add((typeof(UMP45), SoundType.Reload), Resources.Load<AudioClip>("Sound/AK_reload"));
        Sounds.Add((typeof(UMP45), SoundType.FailShot), Resources.Load<AudioClip>("Sound/AK_Fail"));
        Sounds.Add((typeof(KitchenKnife), SoundType.MeleeStrike), Resources.Load<AudioClip>("Sound/FightingSFX_Whoosh_006"));
        Sounds.Add((typeof(Character), SoundType.BareHandStrike), Resources.Load<AudioClip>("Sound/FightingSFX_PunchWhoosh_Dry_009"));

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
        Character.Inventory.AddItem(new Ammo762x39mm(), 45);

        //Character.Inventory.AddItem(new Ammo545x39mm(), 30);
    }
        
}
