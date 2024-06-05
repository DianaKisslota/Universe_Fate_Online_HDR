using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StoragePosition
{
    public Item Item { get; private set; }
    public int MaxCount { get; private set; }
    public int Count { get; set; }

    public StoragePosition(Item item, int _capacity)
    {
        Item = item;
        MaxCount = _capacity;
    }

    public int TryAddItem(Item item, int number)
    {
        int rest = 0;
        var canAdd = MaxCount - Count;
        var added = number;
        if (added > canAdd)
        {
            added = canAdd;
            rest = number - added;
        }
        Count += added;

        return rest;
    }
}

