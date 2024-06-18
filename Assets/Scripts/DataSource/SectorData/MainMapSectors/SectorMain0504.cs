public class SectorMain0504 : SectorData
{
    public SectorMain0504(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
