using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StorageSlot : DropSlot
{
    [SerializeField] GameObject _itemsParent;

    private Storage _storage;
    private List<GameObject> _children = new List<GameObject>();

    public Storage Storage
    {
        get { return _storage; }
        set { _storage = value; }
    }

    private void OnEnable()
    {
        FillSlots();
    }

    protected virtual void FillSlots()
    {
        while (_children.Count > 0)
        {
            var itemObject = _children[0];
            _children.Remove(itemObject);
            Destroy(itemObject);
        }

        foreach (StoragePosition position in _storage.Items)
        {
            var itemPresenter = ItemFactory.CreateItemPresenter(position.Item.GetType(), _itemsParent.transform);
            itemPresenter.Count = position.Count;

            _children.Add(itemPresenter.gameObject);
        }
    }

    protected override bool ItemAccepted(Item item)
    {
        Storage.AddItem(item);
        return true;
    }

    protected override void DropProcess(ItemPresenter itemPresenter)
    {
        base.DropProcess(itemPresenter);
        _children.Add(itemPresenter.gameObject);
    }

    public override void OnItemLeave(Item item)
    {
        var itemObject = _children.FirstOrDefault(x => x.TryGetComponent<ItemPresenter>(out var presenter) && presenter.Item == item);
        if (itemObject != null)
        {
            _children.Remove(itemObject);
            Destroy(itemObject);
        }
        base.OnItemLeave(item);
    }
}
