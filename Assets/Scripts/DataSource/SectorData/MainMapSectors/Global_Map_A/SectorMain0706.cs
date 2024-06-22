public class SectorMain0706 : SectorData
{
    public SectorMain0706(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
