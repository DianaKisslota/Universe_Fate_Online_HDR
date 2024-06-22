public class SectorMain0515 : SectorData
{
    public SectorMain0515(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
