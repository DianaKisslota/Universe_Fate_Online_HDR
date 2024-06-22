public class SectorMain0615 : SectorData
{
    public SectorMain0615(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
