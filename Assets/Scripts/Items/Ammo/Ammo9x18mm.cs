using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ammo9x18mm : Ammo
{
    public Ammo9x18mm()
    {
        Name = "Патроны \n9х18 мм";
        Caliber = Caliber.bullet9x18;
        Weight = 0.099f;
        Volume = 0.017f;
        BaseDamage = 10;
        ArmorPiercing = 1;
    }
}

