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
    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        base.DropProcess(itemPresenter);
        OnItemSet(itemPresenter.Item, this);
    }
}
