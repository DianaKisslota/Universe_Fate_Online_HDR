public class SectorMain0617 : SectorData
{
    public SectorMain0617(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
