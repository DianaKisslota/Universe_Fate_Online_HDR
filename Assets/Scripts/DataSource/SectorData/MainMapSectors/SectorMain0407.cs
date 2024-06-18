public class SectorMain0407 : SectorData
{
    public SectorMain0407(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
