public class SectorMain1112 : SectorData
{
    public SectorMain1112(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
