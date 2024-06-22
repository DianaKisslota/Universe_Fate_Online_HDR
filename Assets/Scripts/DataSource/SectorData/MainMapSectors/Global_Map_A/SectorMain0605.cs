public class SectorMain0605 : SectorData
{
    public SectorMain0605(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
