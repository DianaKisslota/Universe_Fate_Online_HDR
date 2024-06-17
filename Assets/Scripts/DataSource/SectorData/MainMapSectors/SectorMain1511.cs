public class SectorMain1511 : SectorData
{
    public SectorMain1511(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
