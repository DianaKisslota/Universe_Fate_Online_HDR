public class SectorMain1611 : SectorData
{
    public SectorMain1611(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
