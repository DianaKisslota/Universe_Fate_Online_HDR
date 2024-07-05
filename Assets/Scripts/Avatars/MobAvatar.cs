using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MobAvatar : EntityAvatar
{
    protected override void Init()
    {
        
    }

    public override void EntityDie()
    {
        if (Entity is Mob mob && Entity.IsDead)
        {
            var containerObject = ContainerFactory.CreateContainerForModel(new LootContainer(), gameObject);
            foreach (var lootSpawner in mob.Loot)
            {
                lootSpawner.SpawnToStorage(containerObject.Container.Storage);
            }
        }

        base.EntityDie();
    }

}

