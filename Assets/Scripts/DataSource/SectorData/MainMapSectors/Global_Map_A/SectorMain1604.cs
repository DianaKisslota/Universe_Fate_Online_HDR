public class SectorMain1604 : SectorData
{
    public SectorMain1604(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
