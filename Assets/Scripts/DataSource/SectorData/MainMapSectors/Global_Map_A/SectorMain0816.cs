public class SectorMain0816 : SectorData
{
    public SectorMain0816(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
