using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ReloadSlot : DropSlot
{
    protected override bool IsItemAccessible(Item item)
    {
        return item is Ammo;
    }

    protected override bool ItemAccepted(ItemPresenter itemPresenter)
    {
        var slotItem = GetComponent<ItemPresenter>();
        if (slotItem.Item is RangeWeapon weapon)
        { 
            if (itemPresenter.Item is Ammo ammo)
            {
                var amountToLoad = weapon.AmmoCapacity - weapon.AmmoCount;

                if (weapon.Caliber == ammo.Caliber && (amountToLoad > 0 || weapon.CurrentAmmoType != ammo.GetType()))
                {
                    if (weapon.CurrentAmmoType != null && weapon.CurrentAmmoType != ammo.GetType())
                    {
                        Debug.LogError("Не тот вид боеприпаса");  //TODO: Если перезаряжаем другим видом патронов, выгрузить старые патроны
                    }

                    if (itemPresenter.Count < amountToLoad)
                        amountToLoad = itemPresenter.Count;                    
                    itemPresenter.Count -= amountToLoad;
                    if (TryGetComponent<ItemPresenter>(out var weaponPresenter))
                    {
                        weapon.Reload(ammo, amountToLoad);
                        weaponPresenter.RefreshInfo();
                    }
                        
                    var oldSlot = itemPresenter.OldParent.GetComponent<StorageSlot>();                    
                    oldSlot?.OnWeaponReloaded(slotItem, itemPresenter, amountToLoad);
                }
            }            
        }
        return false;
    }

}

