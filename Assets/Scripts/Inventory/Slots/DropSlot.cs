using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        var transferredObject = eventData.pointerDrag;
        var transferredItemPresenter = transferredObject.GetComponent<ItemPresenter>();
        if (transferredItemPresenter != null && IsItemAccessible(transferredItemPresenter.Item) && ItemAccepted(transferredItemPresenter.Item))
        {
            DropProcess(transferredItemPresenter);
        }
    }

    protected virtual bool IsItemAccessible(Item item)
    {
        return true;
    }

    protected virtual bool ItemAccepted(Item item)
    {
        return true;
    }

    protected virtual void DropProcess(ItemPresenter itemPresenter)
    {
        itemPresenter.transform.SetParent(transform);
        itemPresenter.transform.localPosition = Vector3.zero;
        if (itemPresenter.OldParent.gameObject.TryGetComponent<ItemSlot>(out var oldParentItemSlot))
        {
            oldParentItemSlot.SetFree();
        }
    }
}
