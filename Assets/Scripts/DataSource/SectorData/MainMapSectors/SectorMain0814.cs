public class SectorMain0814 : SectorData
{
    public SectorMain0814(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
