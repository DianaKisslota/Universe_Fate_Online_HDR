public class SectorMain1405 : SectorData
{
    public SectorMain1405(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
