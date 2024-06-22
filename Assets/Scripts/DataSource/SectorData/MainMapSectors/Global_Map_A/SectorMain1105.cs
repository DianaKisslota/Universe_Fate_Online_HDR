public class SectorMain1105 : SectorData
{
    public SectorMain1105(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
