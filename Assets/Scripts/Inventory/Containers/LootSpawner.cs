using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootSpawner
{
    public Type LootType { get; private set; }
    public int MinSpawn { get; private set; }
    public int MaxSpawn { get; private set; }

    public LootSpawner(Type lootType, int minSpawn, int maxSpawn = 0)
    {
        LootType = lootType;
        MinSpawn = minSpawn;
        MaxSpawn = maxSpawn;
    }

    public void SpawnToStorage(Storage storage)
    {
        int numberSpawned = MinSpawn;

        if (MaxSpawn > 0)
            numberSpawned = Random.Range(MinSpawn, MaxSpawn + 1);

        for(int i = 0; i < numberSpawned; i++)
        {
            var loot = Activator.CreateInstance(LootType);
            storage.AddItem(loot as Item);
        }

    }
}

