public class SectorMain0509 : SectorData
{
    public SectorMain0509(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
