public class SectorMain1315 : SectorData
{
    public SectorMain1315(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
