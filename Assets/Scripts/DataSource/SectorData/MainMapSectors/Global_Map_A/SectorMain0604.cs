public class SectorMain0604 : SectorData
{
    public SectorMain0604(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
