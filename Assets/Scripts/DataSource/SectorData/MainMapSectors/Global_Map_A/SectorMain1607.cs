public class SectorMain1607 : SectorData
{
    public SectorMain1607(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
