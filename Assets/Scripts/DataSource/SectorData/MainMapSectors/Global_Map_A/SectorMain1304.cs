public class SectorMain1304 : SectorData
{
    public SectorMain1304(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
