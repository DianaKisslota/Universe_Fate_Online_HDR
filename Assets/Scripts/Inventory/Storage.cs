using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

public class Storage
{
    public List<StoragePosition> Items { get; private set; } = new List<StoragePosition>();

    private int _positionCapacity;

    public Storage(int positionCapacity)
    {
        _positionCapacity = positionCapacity;
    }

    public void AddPosition(StoragePosition position)
    {
        position.Empty += CheckStoragePosition;
        Items.Add(position);
    }

    private void RemovePosition(StoragePosition position)
    {
        position.Empty -= CheckStoragePosition;
        Items.Remove(position);
    }

    public StoragePosition AddItem(Item item, int number = 1)
    {
        StoragePosition position = null;
        while (number > 0)
        { 
            position = Items.FirstOrDefault(x => x.Item.GetType() == item.GetType() && x.Count < x.MaxCount);
            if (position == null || !position.Item.Stackable)
            {
                position = new StoragePosition(item, _positionCapacity);
                AddPosition(position);
            }

            number = position.TryAddItem(item, number);
        }
        return position;
    }

    public void RemoveItem(Item item)
    {
        var position = Items.FirstOrDefault(x => x.Item == item);
        if (position != null)
        {
            RemovePosition(position);
        }
    }

    public void Clear()
    {
        for(var i = Items.Count - 1; i > -1; i--)
            RemovePosition(Items[i]);
    }

    public void DecreaseItemCount(Item item, int number)
    {
        var position = Items.FirstOrDefault(x => x.Item == item);
        if (position != null)
        { 
            position.Count -= number;
            if (position.Count < 1)
                RemoveItem(item);
        }
    }

    private void CheckStoragePosition(StoragePosition storagePosition) 
    { 
        if (storagePosition.Count == 0)
        {
            RemovePosition(storagePosition);
        }
    }

}

