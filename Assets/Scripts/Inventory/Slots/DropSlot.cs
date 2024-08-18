using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public event Action<Item, DropSlot> ItemLeave;
    public event Action<Item, DropSlot> ItemSet;
    public event Action<DropSlot, DropSlot, ItemPresenter> ItemPresenterSet;


    [SerializeField] protected SlotType _slotType;
    public SlotType SlotType => _slotType;
    public virtual void OnItemLeave(Item item)
    {
        ItemLeave?.Invoke(item, this);
    }

    public void OnItemSet(Item item, DropSlot slot)
    {
        ItemSet?.Invoke(item, slot);
    }

    public virtual void OnPresenterSet(ItemPresenter itemPresenter, DropSlot sourceSlot)
    {
        ItemPresenterSet?.Invoke(sourceSlot, this, itemPresenter);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var transferredObject = eventData.pointerDrag;
        var transferredItemPresenter = transferredObject.GetComponent<ItemPresenter>();
        if (transferredItemPresenter != null && IsItemAccessible(transferredItemPresenter.Item) && ItemAccepted(transferredItemPresenter))
        {
            DropProcess(transferredItemPresenter);
        }
    }

    protected virtual bool IsItemAccessible(Item item)
    {
        return true;
    }

    protected virtual bool ItemAccepted(ItemPresenter itemPresenter)
    {
        return true;
    }

    protected virtual void DropProcess(ItemPresenter itemPresenter)
    {
        itemPresenter.SetToParent(transform);
        if (itemPresenter.OldParent.gameObject.TryGetComponent<ItemSlot>(out var oldParentItemSlot))
        {
            oldParentItemSlot.SetFree();
        }
        OnItemSet(itemPresenter.Item, this);
    }
}
