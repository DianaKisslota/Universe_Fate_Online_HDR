public class SectorMain1006 : SectorData
{
    public SectorMain1006(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
