public class SectorMain1005 : SectorData
{
    public SectorMain1005(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
