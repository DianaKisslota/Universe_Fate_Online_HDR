public class SectorMain0905 : SectorData
{
    public SectorMain0905(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
