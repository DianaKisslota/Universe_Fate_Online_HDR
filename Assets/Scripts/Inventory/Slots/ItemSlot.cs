using UnityEngine;
public enum SlotType
{
    Undefined,
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
    [SerializeField] protected GameObject _backgroungImage;

    private ItemPresenter _presenter;

    protected bool _isOccuped;
    public virtual void SetFree()
    {
        _isOccuped = false;
        _backgroungImage.SetActive(true);
    }



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

    protected override bool ItemAccepted(ItemPresenter itemPresenter)
    {
        return !_isOccuped;
    }

    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        base.DropProcess(itemPresenter);
        _presenter = itemPresenter;
        _backgroungImage.SetActive(false);
        _isOccuped = true;
    }

    public override void OnItemLeave(Item item)
    {
        _presenter = null;
        SetFree();
        base.OnItemLeave(item);
    }

    public void InitSlot(Item item)
    {
        if (_presenter != null)
            Destroy(_presenter.gameObject);

        if (item == null)
        {
            _backgroungImage.SetActive(true);
            _isOccuped = false;
            return;
        }

        var itemPresenter = ItemFactory.CreateItemPresenter(item);
        itemPresenter.HideName();
        itemPresenter.transform.SetParent(this.transform);
        itemPresenter.transform.localPosition = Vector3.zero;
        if(SlotType == SlotType.Shoulder)
        {
            itemPresenter.transform.localEulerAngles = new Vector3(0, 0, -90);
        }
        _backgroungImage.SetActive(false);
        _isOccuped = true;
        _presenter = itemPresenter;
    }
}
