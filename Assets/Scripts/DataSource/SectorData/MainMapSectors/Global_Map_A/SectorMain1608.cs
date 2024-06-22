public class SectorMain1608 : SectorData
{
    public SectorMain1608(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
