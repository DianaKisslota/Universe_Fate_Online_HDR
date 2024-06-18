public class SectorMain0704 : SectorData
{
    public SectorMain0704(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
