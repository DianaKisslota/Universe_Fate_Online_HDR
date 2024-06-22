public class SectorMain1208 : SectorData
{
    public SectorMain1208(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
