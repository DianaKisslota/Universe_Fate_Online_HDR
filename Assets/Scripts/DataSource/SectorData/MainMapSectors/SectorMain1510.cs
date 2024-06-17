public class SectorMain1510 : SectorData
{
    public SectorMain1510(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
