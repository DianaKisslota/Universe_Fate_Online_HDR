public class SectorMain1412 : SectorData
{
    public SectorMain1412(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
