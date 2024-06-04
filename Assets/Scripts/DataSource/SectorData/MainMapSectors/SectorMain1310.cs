public class SectorMain1310 : SectorData
{
    public SectorMain1310(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
