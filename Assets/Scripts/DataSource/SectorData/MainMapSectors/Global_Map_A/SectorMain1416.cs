public class SectorMain1416 : SectorData
{
    public SectorMain1416(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
