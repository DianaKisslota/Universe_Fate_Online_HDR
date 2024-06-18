public class SectorMain0717 : SectorData
{
    public SectorMain0717(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
