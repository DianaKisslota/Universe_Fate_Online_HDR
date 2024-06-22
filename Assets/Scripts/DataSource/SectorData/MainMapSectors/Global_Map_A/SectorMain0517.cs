public class SectorMain0517 : SectorData
{
    public SectorMain0517(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
