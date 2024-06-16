using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (weapon.Caliber == ammo.Caliber)
                { 
                    var amountToLoad = weapon.AmmoCapacity - weapon.AmmoCount;
                    if (itemPresenter.Count < amountToLoad)
                        amountToLoad = itemPresenter.Count;
                    weapon.AmmoCount += amountToLoad;
                    itemPresenter.Count -= amountToLoad;
                    if (TryGetComponent<ItemPresenter>(out var weaponPresenter))
                        weaponPresenter.RefreshInfo();
                }
            }            
        }
        return false;
    }

}

