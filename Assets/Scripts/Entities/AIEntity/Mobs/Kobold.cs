using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Kobold : Mob
{
    public Kobold()
    {
        Name = "Кобольд";
        Description = "Мутировавшая подземная форма жизни. Теперь уже невозможно понять, какая именно. Кобольды почти слепы, зато обладают отличным слухом и обонянием.";
        AddLoot(typeof(MetalScrap), 1, 3);
    }
    protected override void Init()
    {
        Strength = 4;
        Perception = 3;
        Agility = 7;
        Constitution = 3;
        Intelligence = 5;
        Will = 6;

        GroupID = 1;
        AggressionLevel = 2;

        base.Init();
    }

}

