public class SectorMain0514 : SectorData
{
    public SectorMain0514(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
