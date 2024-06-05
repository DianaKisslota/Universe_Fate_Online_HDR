using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoragePresenter : MonoBehaviour
{
    [SerializeField] GameObject _itemsParent;

    private Storage _storage;
    private List<GameObject> _children = new List<GameObject>();


    public Storage Storage 
    {  get { return _storage; } 
       set { _storage = value; }
    }

    private void OnEnable()
    {
        while (_children.Count > 0)
        {
            var item = _children[0];
            _children.Remove(item);
            Destroy(item);
        }

        foreach (StoragePosition position in _storage.Items) 
        {
            var itemPresenter = ItemFactory.CreateItemPresenter(position.Item.GetType(), _itemsParent.transform);
            itemPresenter.Count = position.Count;

            _children.Add(itemPresenter.gameObject);
        }
    }
}
