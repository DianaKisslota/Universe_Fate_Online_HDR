using System;
using System.Collections.Generic;

public class Character : BaseEntity
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

    public void UnEquip(Item item, DropSlot slot)
    {
        if (item == MainWeapon)
            MainWeapon = null;
        else
            if (item == SecondaryWeapon)
                SecondaryWeapon = null;
            else
                if (item == ShoulderWeapon)
                    ShoulderWeapon = null;
                else
                    Inventory.RemoveItem(item);
        if (slot is ItemSlot itemSlot)
            OnUnEquip?.Invoke(item, itemSlot.SlotType);
        else
            OnUnEquip?.Invoke(item, SlotType.Undefined);
    }

    public void AddToInventory(Item item, int num)
    {
        Inventory.AddItem(item, num);
    }
}
