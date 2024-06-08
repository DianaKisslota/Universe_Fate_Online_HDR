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

    public List<Skill> Skills { get; set; } = new List<Skill>();
    public Weapon MainWeapon { get; set; }
    public Weapon SecondaryWeapon { get; set; }
    public Weapon ShoulderWeapon { get; set; }

    public CharacterInventory Inventory { get; private set; }  = new CharacterInventory();

    public void Equip(SlotType slot, Item item)
    {
        switch (slot)
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
        }
    }

    public void UnEquip(Item item)
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
    }
}
