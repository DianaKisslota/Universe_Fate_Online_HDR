using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class RangeWeapon : Weapon
{
    private int _ammoCount;
    public Caliber Caliber { get; set; }
    public int AmmoCapacity {  get; set; }
    public Type CurrentAmmoType { get; set; } 
    public int AmmoCount {  get; set; }
}

