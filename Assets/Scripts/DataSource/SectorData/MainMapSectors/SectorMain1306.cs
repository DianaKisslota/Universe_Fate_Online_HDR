public class SectorMain1306 : SectorData
{
    public SectorMain1306(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
