public class SectorMain0506 : SectorData
{
    public SectorMain0506(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
