public class SectorMain0406 : SectorData
{
    public SectorMain0406(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
