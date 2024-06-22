public class SectorMain0805 : SectorData
{
    public SectorMain0805(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
