public class SectorMain1204 : SectorData
{
    public SectorMain1204(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
