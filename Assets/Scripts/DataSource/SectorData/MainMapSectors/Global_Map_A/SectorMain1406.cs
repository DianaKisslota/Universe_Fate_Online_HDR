public class SectorMain1406 : SectorData
{
    public SectorMain1406(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
