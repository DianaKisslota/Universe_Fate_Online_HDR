public class SectorMain1516 : SectorData
{
    public SectorMain1516(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
