public class SectorMain0707 : SectorData
{
    public SectorMain0707(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
