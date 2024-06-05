public class SectorMain1413 : SectorData
{
    public SectorMain1413(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
