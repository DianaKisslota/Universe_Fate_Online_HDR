public class SectorMain1508 : SectorData
{
    public SectorMain1508(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
