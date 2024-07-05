using System;
using System.Collections.Generic;

public abstract class Mob : AIEntity
{
    public int GroupID {  get; set; }
    public int AggressionLevel { get; set; }
    public List<LootSpawner> Loot { get; set; } = new();

    public void AddLoot(Type lootType, int minSpawned, int maxSpawned = 0)
    {
        Loot.Add(new LootSpawner(lootType, minSpawned, maxSpawned));
    }
}

