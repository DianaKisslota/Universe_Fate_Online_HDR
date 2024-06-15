using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ammo545x39mm : Ammo
{
    public Ammo545x39mm()
    {
        Name = "Патроны \n5,45х39 мм";
        Caliber = Caliber.bullet545x39;
        Weight = 0.0102f;
        Volume = 0.036f;
        BaseDamage = 50;
        ArmorPiercing = 5;
    }
}

