public class SectorMain1605 : SectorData
{
    public SectorMain1605(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
