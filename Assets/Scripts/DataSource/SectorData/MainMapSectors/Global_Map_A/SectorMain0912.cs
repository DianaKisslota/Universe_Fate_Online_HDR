public class SectorMain0912 : SectorData
{
    public SectorMain0912(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
