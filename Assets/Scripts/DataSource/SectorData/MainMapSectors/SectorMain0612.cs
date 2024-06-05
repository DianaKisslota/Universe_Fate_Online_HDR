public class SectorMain0612 : SectorData
{
    public SectorMain0612(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}

