public class SectorMain0414 : SectorData
{
    public SectorMain0414(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
