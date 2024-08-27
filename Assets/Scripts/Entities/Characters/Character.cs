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


    protected override void Init()
    {
        Strength = 6;
        Perception = 7;
        Agility = 6;
        Constitution = 6;
        Intelligence = 8;
        Will = 6;

        base.Init();
    }

    public event Action<Item, SlotType> OnEquip;
    public event Action<Item, SlotType> OnUnEquip;

    public List<Skill> Skills { get; set; } = new List<Skill>();
    public Weapon MainWeapon { get; set; }
    public Weapon SecondaryWeapon { get; set; }
    public Weapon ShoulderWeapon { get; set; }

    public CharacterInventory Inventory { get; set; }  = new CharacterInventory();
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

    public Weapon Weapon => MainWeapon;

    public void Equip(Item item, SlotType slotType)
    {
        if (item == null)
        {
            Item unequipedItem = null;
            switch (slotType)
            {
                case SlotType.MainWeapon:
                    unequipedItem = MainWeapon;
                    break;
                case SlotType.SecondaryWeapon:
                    unequipedItem = SecondaryWeapon;
                    break;

                case SlotType.Shoulder:
                    unequipedItem = ShoulderWeapon;
                    break;
            }

            if (unequipedItem != null)
                UnEquip(unequipedItem);
            return;
        }
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
