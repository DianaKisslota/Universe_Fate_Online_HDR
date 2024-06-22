public class SectorMain0505 : SectorData
{
    public SectorMain0505(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
