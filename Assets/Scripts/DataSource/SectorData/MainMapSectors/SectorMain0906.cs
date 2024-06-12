public class SectorMain0906 : SectorData
{
    public SectorMain0906(int x, int y) : base("Main", x, y)
    {
    AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
