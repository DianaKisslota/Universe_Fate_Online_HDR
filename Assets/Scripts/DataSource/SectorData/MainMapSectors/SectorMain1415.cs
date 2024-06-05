public class SectorMain1415 : SectorData
{
    public SectorMain1415(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
