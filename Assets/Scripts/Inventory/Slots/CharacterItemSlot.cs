using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemSlot : ItemSlot
{
    public Character Character => Global.Character;

    private void Awake()
    {
        ItemLeave += Character.UnEquip;
    }
}
