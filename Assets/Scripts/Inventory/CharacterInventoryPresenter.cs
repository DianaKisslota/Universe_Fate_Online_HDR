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
    public List<CharacterItemSlot> ItemSlots;
    private Character Character => Global.Character;

    private void Awake()
    {
        ItemSlots = new List<CharacterItemSlot>()
        {
            _mainWeapon, _secondaryWeapon, _shoulder
        };
        _mainWeapon.InitSlot(Character.MainWeapon);
        _secondaryWeapon.InitSlot(Character.SecondaryWeapon);
        _shoulder.InitSlot(Character.ShoulderWeapon);
    }
}
