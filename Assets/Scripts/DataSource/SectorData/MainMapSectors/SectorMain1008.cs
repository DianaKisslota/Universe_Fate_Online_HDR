public class SectorMain1008 : SectorData
{
    public SectorMain1008(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
