public class SectorMain0715 : SectorData
{
    public SectorMain0715(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
