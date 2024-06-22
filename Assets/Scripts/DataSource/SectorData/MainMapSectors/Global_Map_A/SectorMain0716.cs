public class SectorMain0716 : SectorData
{
    public SectorMain0716(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
