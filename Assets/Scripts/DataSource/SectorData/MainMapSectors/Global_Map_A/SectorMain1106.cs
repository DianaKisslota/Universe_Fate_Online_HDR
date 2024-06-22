public class SectorMain1106 : SectorData
{
    public SectorMain1106(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
