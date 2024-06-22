public class SectorMain0511 : SectorData
{
    public SectorMain0511(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
