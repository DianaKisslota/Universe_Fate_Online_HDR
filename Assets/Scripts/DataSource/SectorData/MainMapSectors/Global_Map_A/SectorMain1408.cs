public class SectorMain1408 : SectorData
{
    public SectorMain1408(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
