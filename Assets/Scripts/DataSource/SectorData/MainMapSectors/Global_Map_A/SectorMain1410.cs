public class SectorMain1410 : SectorData
{
    public SectorMain1410(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
