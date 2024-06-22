public class SectorMain0512 : SectorData
{
    public SectorMain0512(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
