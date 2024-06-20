using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryPresenter : MonoBehaviour
{
    [SerializeField] CharacterItemSlot _mainWeapon;
    [SerializeField] CharacterItemSlot _secondaryWeapon;
    [SerializeField] CharacterItemSlot _shoulder;

    [SerializeField] CharacterInventorySlot _inventory;

    public CharacterInventorySlot Inventory => _inventory;
    public List<CharacterItemSlot> _itemSlots = null;
    public List<CharacterItemSlot> ItemSlots
    {
        get
        {
            if (_itemSlots == null || _itemSlots.Count == 0) 
                _itemSlots = new List<CharacterItemSlot>()
                {
                    _mainWeapon, _secondaryWeapon, _shoulder
                };
            return _itemSlots;

        }
    }
    private Character Character => Global.Character;

    private void Awake()
    {
        RefreshItemSlots();
    }

    public void RefreshItemSlots()
    {
        _mainWeapon.InitSlot(Character.MainWeapon);
        _secondaryWeapon.InitSlot(Character.SecondaryWeapon);
        _shoulder.InitSlot(Character.ShoulderWeapon);
    }
}
