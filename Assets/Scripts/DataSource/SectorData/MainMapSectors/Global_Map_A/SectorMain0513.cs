public class SectorMain0513 : SectorData
{
    public SectorMain0513(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
