public class SectorMain0616 : SectorData
{
    public SectorMain0616(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
