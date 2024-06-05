public class SectorMain0714 : SectorData
{
    public SectorMain0714(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
