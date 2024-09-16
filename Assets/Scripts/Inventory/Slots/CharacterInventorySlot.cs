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

    protected override bool IsItemAccessible(Item item)
    {
        if (Character.CurrentAP < Character.ChangeInventoryCast)
            return false;
        else
            return base.IsItemAccessible(item);
    }

    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        if (itemPresenter?.Count > 0)
            OnItemSet(itemPresenter.Item, this);
        base.DropProcess(itemPresenter);
    }

    private void OnUnequip(Item item, DropSlot slot)
    {
        Character.UnEquip(item);
    }
}
