public class SectorMain0813 : SectorData
{
    public SectorMain0813(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
