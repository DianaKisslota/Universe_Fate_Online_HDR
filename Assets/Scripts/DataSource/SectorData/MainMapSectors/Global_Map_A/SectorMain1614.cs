public class SectorMain1614 : SectorData
{
    public SectorMain1614(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
