public class SectorMain0806 : SectorData
{
    public SectorMain0806(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
