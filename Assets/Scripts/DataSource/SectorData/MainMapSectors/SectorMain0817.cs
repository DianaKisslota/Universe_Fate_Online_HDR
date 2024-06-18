public class SectorMain0817 : SectorData
{
    public SectorMain0817(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
