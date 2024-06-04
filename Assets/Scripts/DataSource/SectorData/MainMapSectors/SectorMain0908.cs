public class SectorMain0908 : SectorData
{
    public SectorMain0908(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
