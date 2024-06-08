using UnityEngine;
public enum SlotType
{
    MainWeapon,
    SecondaryWeapon,
    Shoulder,
    Helm,
    Armor,
    Boots,
    BackPack
}

public class ItemSlot : DropSlot
{
    [SerializeField] protected SlotType _slotType;
    [SerializeField] protected GameObject _backgroungImage;

    protected bool _isOccuped;
    public virtual void SetFree()
    {
        _isOccuped = false;
        _backgroungImage.SetActive(true);
    }

    public SlotType SlotType => _slotType;

    protected override bool IsItemAccessible(Item item)
    {
        switch (_slotType)
        {
            case SlotType.MainWeapon:
                return item is Weapon;
            case SlotType.SecondaryWeapon:
                return item is Weapon weapon && (weapon.WeaponType == WeaponType.Pistol || weapon.WeaponType == WeaponType.SMG
                                                || weapon.WeaponType == WeaponType.Knife);
            case SlotType.Shoulder:
                return item is Weapon weapon1 && (weapon1.WeaponType == WeaponType.Rifle || weapon1.WeaponType == WeaponType.SMG
                                                || weapon1.WeaponType == WeaponType.AssaultRifle || weapon1.WeaponType == WeaponType.MG);
        }

        return false;
    }

    protected override bool ItemAccepted(Item item)
    {
        return !_isOccuped;
    }

    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        base.DropProcess(itemPresenter);
        _backgroungImage.SetActive(false);
        _isOccuped = true;
    }
}
