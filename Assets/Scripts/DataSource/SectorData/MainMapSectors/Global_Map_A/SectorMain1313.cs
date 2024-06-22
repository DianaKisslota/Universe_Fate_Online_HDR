public class SectorMain1313 : SectorData
{
    public SectorMain1313(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
