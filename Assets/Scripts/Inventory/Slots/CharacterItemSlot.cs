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
        ItemLeave += Character.UnEquip;        
    }

    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        base.DropProcess(itemPresenter);
        OnItemSet(itemPresenter.Item, this);
    }


}
