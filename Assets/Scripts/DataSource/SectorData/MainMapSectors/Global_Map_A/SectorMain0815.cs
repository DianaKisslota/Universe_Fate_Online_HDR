public class SectorMain0815 : SectorData
{
    public SectorMain0815(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
