public class SectorMain0408 : SectorData
{
    public SectorMain0408(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
