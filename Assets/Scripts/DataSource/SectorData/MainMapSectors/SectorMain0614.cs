public class SectorMain0614 : SectorData
{
    public SectorMain0614(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}

