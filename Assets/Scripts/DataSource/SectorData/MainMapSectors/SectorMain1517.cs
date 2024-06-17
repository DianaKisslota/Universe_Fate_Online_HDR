public class SectorMain1517 : SectorData
{
    public SectorMain1517(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
