public class SectorMain1212 : SectorData
{
    public SectorMain1212(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
