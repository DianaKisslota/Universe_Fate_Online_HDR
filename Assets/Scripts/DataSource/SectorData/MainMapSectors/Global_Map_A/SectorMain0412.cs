public class SectorMain0412 : SectorData
{
    public SectorMain0412(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}

