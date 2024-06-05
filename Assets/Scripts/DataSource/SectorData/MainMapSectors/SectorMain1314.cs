public class SectorMain1314 : SectorData
{
    public SectorMain1314(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
