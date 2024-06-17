public class SectorMain1514 : SectorData
{
    public SectorMain1514(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
