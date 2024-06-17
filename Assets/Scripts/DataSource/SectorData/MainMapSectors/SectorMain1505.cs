public class SectorMain1505 : SectorData
{
    public SectorMain1505(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
