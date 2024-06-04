public class SectorMain1206 : SectorData
{
    public SectorMain1206(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
