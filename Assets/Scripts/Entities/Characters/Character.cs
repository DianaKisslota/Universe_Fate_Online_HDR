using System;
using System.Collections.Generic;

public class Character : BaseEntity, IAttacker
{
    public string ClassName {  get; set; }
    private int _expirience;
    public int Expirience
    {
        get { return _expirience; }
        set { _expirience = value; }
    }

    public event Action<Item, SlotType> OnEquip;
    public event Action<Item, SlotType> OnUnEquip;

    public List<Skill> Skills { get; set; } = new List<Skill>();
    public Weapon MainWeapon { get; set; }
    public Weapon SecondaryWeapon { get; set; }
    public Weapon ShoulderWeapon { get; set; }

    public CharacterInventory Inventory { get; private set; }  = new CharacterInventory();
    public float BaseHitChance 
    {
        get
        {
            if (MainWeapon != null && MainWeapon is RangeWeapon)
            { 
                return BaseRangeHitChance;
            }
            else
            {
                return BaseMeleeHitChance;
            }
        }
    }
    public float BaseDamage 
    {
        get
        {
            if (MainWeapon != null && MainWeapon is RangeWeapon rangeWeapon)
            {
                return rangeWeapon.Ammo.BaseDamage;
            }
            else
            {
                return BaseMeleeDamage;
            }
        }
    }

    public void Equip(Item item, SlotType slotType)
    {
        switch (slotType)
        {
            case SlotType.MainWeapon:
                MainWeapon = (Weapon)item;
                break;
            case SlotType.SecondaryWeapon:
                SecondaryWeapon = (Weapon)item;
                break;

            case SlotType.Shoulder:
                ShoulderWeapon = (Weapon)item;
                break;
            case SlotType.Undefined:
                Inventory.AddItem(item);
                break;
        }

        OnEquip?.Invoke(item, slotType);
    }
    public void Equip(Item item, DropSlot slot)
    {
        var slotType = (slot as ItemSlot).SlotType;
        Equip(item, slotType);
    }

    public void UnEquip(Item item)
    {
        SlotType slot = SlotType.Undefined;
        if (item == MainWeapon)
        {
            MainWeapon = null;
            slot = SlotType.MainWeapon;
        }
        else
        if (item == SecondaryWeapon)
        {
            SecondaryWeapon = null;
            slot = SlotType.SecondaryWeapon;
        }
        else
        if (item == ShoulderWeapon)
        {
            ShoulderWeapon = null;
            slot = SlotType.Shoulder;
        }
        else
        {
            Inventory.RemoveItem(item);
        }
        OnUnEquip?.Invoke(item, slot);
    }

    public void AddToInventory(Item item, int num)
    {
        Inventory.AddItem(item, num);
    }
}
