public class SectorMain0411 : SectorData
{
    public SectorMain0411(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
