public abstract class Container
{
    public Storage Storage { get; set; }

    protected Container()
    {
        Storage = new Storage(100);
    }

    public void AddItem(Item item)
    {
        Storage.AddItem(item);
    }

    public void RemoveItem(Item item)
    { 
        Storage.RemoveItem(item);
    }
}

