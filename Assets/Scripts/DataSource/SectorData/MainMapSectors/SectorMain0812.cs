public class SectorMain0812 : SectorData
{
    public SectorMain0812(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
