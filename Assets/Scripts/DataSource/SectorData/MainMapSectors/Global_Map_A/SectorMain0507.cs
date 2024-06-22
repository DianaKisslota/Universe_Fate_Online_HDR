public class SectorMain0507 : SectorData
{
    public SectorMain0507(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
