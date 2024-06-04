public class SectorMain1407 : SectorData
{
    public SectorMain1407(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
