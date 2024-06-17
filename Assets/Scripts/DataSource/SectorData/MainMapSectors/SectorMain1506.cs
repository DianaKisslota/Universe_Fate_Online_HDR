public class SectorMain1506 : SectorData
{
    public SectorMain1506(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
