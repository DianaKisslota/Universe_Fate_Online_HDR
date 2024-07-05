using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Reptiloid : Mob
{
    public Reptiloid()
    {
        Name = "Рептилоид";
        Description = "Вас много раз предупреждали об их существовании, а вы не верили.";

        //AddLoot("Шкура рептилоида 0-1 шт.");
    }

    protected override void Init()
    {
        Strength = 7;
        Perception = 5;
        Agility = 6;
        Constitution = 5;
        Intelligence = 5;
        Will = 5;

        GroupID = 1;
        AggressionLevel = 2;

        base.Init();
    }

}

