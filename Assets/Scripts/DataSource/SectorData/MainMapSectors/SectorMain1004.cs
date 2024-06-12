public class SectorMain1004 : SectorData
{
    public SectorMain1004(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
