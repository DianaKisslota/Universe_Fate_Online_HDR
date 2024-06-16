using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class RangeWeapon : Weapon
{
    private int _ammoCount;
    public Caliber Caliber { get; set; }
    public int AmmoCapacity {  get; set; }
    public Type CurrentAmmoType { get; set; } 
    public int AmmoCount 
    {
        get => _ammoCount;
    }

    public void Reload(Ammo ammo, int num)
    {
        _ammoCount += num;
        CurrentAmmoType = ammo.GetType();
      //  AmmoChanged?.Invoke(this, CurrentAmmoType, num, source);
    }

    public void UnLoad(int num)
    {
        _ammoCount -= num;
        if (_ammoCount < 0)
        {
            Debug.LogError("Количество боеприпасов меньше нуля");
        }
    }

    //public event Action<RangeWeapon, Type, int> AmmoChanged;
}

