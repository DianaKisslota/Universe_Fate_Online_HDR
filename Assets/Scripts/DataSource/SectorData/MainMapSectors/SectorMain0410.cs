public class SectorMain0410 : SectorData
{
    public SectorMain0410(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
