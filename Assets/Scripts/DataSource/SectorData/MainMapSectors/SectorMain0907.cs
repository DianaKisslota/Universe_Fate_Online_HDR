public class SectorMain0907 : SectorData
{
    public SectorMain0907(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
