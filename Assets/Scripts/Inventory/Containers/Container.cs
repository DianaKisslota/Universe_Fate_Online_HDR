using System;
using System.Collections.Generic;

public abstract class Container
{
    public Storage Storage { get; set; }

    protected Container()
    {
        Storage = new Storage(100);
    }

    public void AddItem(Item item, int number = 1)
    {
        Storage.AddItem(item, number);
    }

    public void RemoveItem(Item item)
    { 
        Storage.RemoveItem(item);
    }

    public void RestoreStorage(List<ItemTemplate> containerStorage)
    {
        Storage.RestoreStorage(containerStorage);
    }
}

