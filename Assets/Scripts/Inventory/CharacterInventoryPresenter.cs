using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryPresenter : StoragePresenter
{
    private Character Character;

    private void Awake()
    {
        Character = Global.Character;
        Storage = Character.Inventory;
    }
}
