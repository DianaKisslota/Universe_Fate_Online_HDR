public class SectorMain1409 : SectorData
{
    public SectorMain1409(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
