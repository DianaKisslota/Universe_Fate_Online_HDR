public class SectorMain0916 : SectorData
{
    public SectorMain0916(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
