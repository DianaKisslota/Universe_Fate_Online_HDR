public class SectorMain0510 : SectorData
{
    public SectorMain0510(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
