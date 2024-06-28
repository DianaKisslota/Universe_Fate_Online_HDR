using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum FireMode
{
    Undefined,
    SingleShot,
    ShortBurst,
    LongBurst
}

public abstract class RangeWeapon : Weapon
{
    private int _ammoCount;
    private Type _currentAmmoType;
    private Ammo _ammo;
    public Caliber Caliber { get; set; }
    public int AmmoCapacity {  get; set; }
    public Type CurrentAmmoType 
    { get => _currentAmmoType; 
      set
        {
            _currentAmmoType = value;
            if (_currentAmmoType == null)
                _ammo = null;
            else
                _ammo = Activator.CreateInstance(_currentAmmoType) as Ammo;
        } 
    } 
    public Ammo Ammo => _ammo;
    public int AmmoCount 
    {
        get => _ammoCount;
    }
    public int? SingleShot { get; set; } = 1;
    public int? ShortBurst { get; set; } = null;
    public int? LongBurst { get; set; } = null;

    public int? GetFireModeAmmo(FireMode fireMode)
    {
        switch (fireMode)
        {
            case FireMode.SingleShot:
                return SingleShot;
            case FireMode.ShortBurst:
                return ShortBurst;
            case FireMode.LongBurst:
                return LongBurst;
            default: 
                return 0;
        }
    }

    public void Reload(Ammo ammo, int num)
    {
        _ammoCount += num;
        CurrentAmmoType = ammo.GetType();
        AmmoChanged?.Invoke(this, CurrentAmmoType, num);
    }

    public void Reload(Type ammoType, int num)
    {
        _ammoCount += num;
        CurrentAmmoType = ammoType;
          AmmoChanged?.Invoke(this, CurrentAmmoType, num);
    }

    public void UnLoad(int num)
    {
        _ammoCount -= num;
        if (_ammoCount < 0)
        {
            Debug.LogError("Количество боеприпасов меньше нуля");
        }
        AmmoChanged?.Invoke(this, CurrentAmmoType, -num);
    }

    public event Action<RangeWeapon, Type, int> AmmoChanged;
}

