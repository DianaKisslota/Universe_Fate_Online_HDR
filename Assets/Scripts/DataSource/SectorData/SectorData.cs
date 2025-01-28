using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class TransferInfo
{
    public string TransferToScene { get; private set; }
    public string TransferToSector { get; private set; }
    public string TransferCaption {  get; private set; }

    public TransferInfo(string transferToScene, string transferToSector, string transferCaption)
    {
        TransferToScene = transferToScene;
        TransferToSector = transferToSector;
        TransferCaption = transferCaption;
    }
}

public abstract class SectorData
{
    public int X { get; }
    public int Y { get; }
    public bool? IsDark { get; set; } = null;
    // **Изменение: Добавлено свойство для проверки наличия магазина**
    public bool HasShop { get; set; } = false; // Указывает, доступен ли магазин в секторе
    public bool Hospital { get; set; } = false; // Указывает, доступен ли Госпиталь в секторе
    public bool Arena { get; set; } = false; // Указывает, доступен ли Арена в секторе
    public bool Warehouse { get; set; } = false; // Указывает, доступен ли Склад в секторе
    private string _prefix;

    public string Prefix => _prefix;
    public TransferInfo TransferTo { get; set; } = null;
    public bool IsRestricted() => false;
    public SectorData(string prefix, int x, int y)
    {
        _prefix = prefix;
        X = x;
        Y = y;
    }
    public static string CoordsString(int x, int y)
    {
        return x.ToString().PadLeft(2, '0') + y.ToString().PadLeft(2, '0');
    }

    public static string CoordsToID(string prefix, int x, int y)
    {
        return prefix + CoordsString(x, y);
    }
    public string ID => CoordsToID(_prefix, X, Y);
    public string Coords => CoordsString(X, Y);

    public List<string> BattleScenes { get; } = new List<string>();
    public List<EntitySpawner> Monsters { get; } = new List<EntitySpawner>();
    public List<ItemSpawner> Items { get; } = new List<ItemSpawner> ();
    public List<StaticContainer> StaticContainers { get; } = new List<StaticContainer> ();
    public List<SmallContainer> SmallContainers { get; } = new List<SmallContainer>();
    protected List<string> NPC { get; } = new List<string>();

    public void AddBattleScene(string sceneName)
    {
        BattleScenes.Add(sceneName);
    }

    public string GetRandomBattleScene()
    {
        if(BattleScenes.Count == 0)
            return null;
        var sceneIndex = Random.Range(0, BattleScenes.Count);
        return BattleScenes[sceneIndex];
    }
    public void AddItem(Type itemType)
    {
        Items.Add(new ItemSpawner(itemType));
    }

    public void AddMonster(EntitySpawner spawner)
    {
        Monsters.Add(spawner);
    }

    public void AddStaticContainer(StaticContainer container)
    {
        StaticContainers.Add(container);
    }

    public void AddSmallContainer(SmallContainer container)
    {
        SmallContainers.Add(container);
    }

    public void ADDNPC (string npc)
    {
        NPC.Add(npc);
    }
    public string GetMonsterList()
    {
        string result = string.Empty;
        foreach (EntitySpawner monster in Monsters)
        {
            result += monster.MonsterName + "\n";
        }
        return result;
    }

    public string GetNPCList()
    {
        string result = string.Empty;
        foreach (string npc in NPC)
        {
            result += npc + "\n";
        }
        return result;
    }

}
