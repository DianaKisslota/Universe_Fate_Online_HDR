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
        ItemLeave += OnUnequip;
    }
    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        base.DropProcess(itemPresenter);
        if(itemPresenter?.Count > 0)
            OnItemSet(itemPresenter.Item, this);
    }

    private void OnUnequip(Item item, DropSlot slot)
    {
        Character.UnEquip(item);
    }
}
