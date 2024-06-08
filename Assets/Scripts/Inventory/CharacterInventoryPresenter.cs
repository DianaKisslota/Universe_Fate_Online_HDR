using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryPresenter : MonoBehaviour
{
    [SerializeField] CharacterItemSlot _mainWeapon;
    [SerializeField] CharacterItemSlot _secondaryWeapon;
    [SerializeField] CharacterItemSlot _shoulder;

    private Character Character => Global.Character;

    private void Awake()
    {
        _mainWeapon.InitSlot(Character.MainWeapon);
        _secondaryWeapon.InitSlot(Character.SecondaryWeapon);
        _shoulder.InitSlot(Character.ShoulderWeapon);
    }
}
