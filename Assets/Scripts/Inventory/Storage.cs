using System.Collections.Generic;
using System.Linq;

public abstract class Storage
{
    public List<StoragePosition> Items { get; private set; } = new List<StoragePosition>();

    private int _positionCapacity;

    protected Storage(int positionCapacity)
    {
        _positionCapacity = positionCapacity;
    }

    public void AddItem(Item item, int number = 1)
    {
        while (number > 0)
        { 
            var position = Items.FirstOrDefault(x => x.Item.GetType() == item.GetType() && x.Count < x.MaxCount);
            if (position == null)
            {
                position = new StoragePosition(item, _positionCapacity);
                Items.Add(position);
            }

            number = position.TryAddItem(item, number);
        }
    }

    public void RemoveItem(Item item)
    {
        var position = Items.FirstOrDefault(x => x.Item == item);
        if (position != null)
        {
            Items.Remove(position);
        }
    }

}

