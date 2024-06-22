public class SectorMain1007 : SectorData
{
    public SectorMain1007(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
