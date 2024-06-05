public class SectorMain0913 : SectorData
{
    public SectorMain0913(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
