public class SectorMain1013 : SectorData
{
    public SectorMain1013(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
