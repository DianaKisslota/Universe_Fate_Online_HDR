public class SectorMain0405 : SectorData
{
    public SectorMain0405(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
