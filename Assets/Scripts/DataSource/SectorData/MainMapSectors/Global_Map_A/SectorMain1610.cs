public class SectorMain1610 : SectorData
{
    public SectorMain1610(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
