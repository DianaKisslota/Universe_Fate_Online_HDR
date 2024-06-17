public class SectorMain1507 : SectorData
{
    public SectorMain1507(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
