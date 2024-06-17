public class SectorMain1615 : SectorData
{
    public SectorMain1615(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
