public class SectorMain0416 : SectorData
{
    public SectorMain0416(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
