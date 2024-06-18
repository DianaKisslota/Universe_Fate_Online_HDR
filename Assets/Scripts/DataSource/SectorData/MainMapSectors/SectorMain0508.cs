public class SectorMain0508 : SectorData
{
    public SectorMain0508(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
