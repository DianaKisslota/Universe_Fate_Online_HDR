public class SectorMain0904 : SectorData
{
    public SectorMain0904(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
