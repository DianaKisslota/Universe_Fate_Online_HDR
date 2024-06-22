public class SectorMain1616 : SectorData
{
    public SectorMain1616(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
