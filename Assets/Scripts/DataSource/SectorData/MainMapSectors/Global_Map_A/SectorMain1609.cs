public class SectorMain1609 : SectorData
{
    public SectorMain1609(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
