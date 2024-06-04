public class SectorMain1309 : SectorData
{
    public SectorMain1309(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
