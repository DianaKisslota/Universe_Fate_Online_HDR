public class SectorMain0413 : SectorData
{
    public SectorMain0413(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
