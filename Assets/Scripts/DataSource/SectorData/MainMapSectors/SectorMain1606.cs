public class SectorMain1606 : SectorData
{
    public SectorMain1606(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
