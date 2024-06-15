using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ammo762x39mm : Ammo
{
    public Ammo762x39mm()
    {
        Name = "Патроны \n7,62х39 мм";
        Caliber = Caliber.bullet762x39;
        Weight = 0.0163f;
        Volume = 0.041f;
        BaseDamage = 65;
        ArmorPiercing = 7;
    }
}

