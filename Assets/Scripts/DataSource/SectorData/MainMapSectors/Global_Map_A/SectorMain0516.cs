public class SectorMain0516 : SectorData
{
    public SectorMain0516(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
