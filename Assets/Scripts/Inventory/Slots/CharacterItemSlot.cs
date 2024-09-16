using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemSlot : ItemSlot
{
    public Character Character => Global.Character;

    private void Awake()
    {
        ItemSet += Character.Equip;
        ItemLeave += OnUnequip;        
    }

    protected override bool IsItemAccessible(Item item)
    {
        if (Character.CurrentAP < Character.ChangeInventoryCast)
            return false;
        else
            return base.IsItemAccessible(item);
    }

    public override void OnPresenterSet(ItemPresenter itemPresenter, DropSlot sourceSlot)
    {
        if (sourceSlot == this)
            OnItemSet(itemPresenter.Item, this);
        else
            base.OnPresenterSet(itemPresenter, sourceSlot);
    }

    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        base.DropProcess(itemPresenter);

    }

    private void OnUnequip(Item item, DropSlot slot)
    {
        Character.UnEquip(item);
    }

    public void RefreshInfo()
    {
        if (_presenter != null)
        {
            _presenter.RefreshInfo();
        }        
    }
}
