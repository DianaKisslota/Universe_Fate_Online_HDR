public class SectorMain0415 : SectorData
{
    public SectorMain0415(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
