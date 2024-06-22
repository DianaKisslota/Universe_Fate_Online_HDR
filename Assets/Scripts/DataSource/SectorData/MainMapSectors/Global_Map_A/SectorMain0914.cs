public class SectorMain0914 : SectorData
{
    public SectorMain0914(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
