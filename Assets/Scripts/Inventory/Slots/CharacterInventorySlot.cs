using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventorySlot : StorageSlot
{
    private Character Character;

    private void Awake()
    {
        Character = Global.Character;
        Storage = Character.Inventory;
        ItemLeave += Character.UnEquip;
    }
}
