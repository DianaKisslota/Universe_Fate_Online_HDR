using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ammo045ACP : Ammo
{
    public Ammo045ACP()
    {
        Name = "Патроны \n.45 ACP";
        Caliber = Caliber.bullet045ACP;
        Weight = 0.021f;
        Volume = 0.11f;
        BaseDamage = 40;
        ArmorPiercing = 2;
    }
}

