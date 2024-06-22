public class SectorMain1617 : SectorData
{
    public SectorMain1617(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
