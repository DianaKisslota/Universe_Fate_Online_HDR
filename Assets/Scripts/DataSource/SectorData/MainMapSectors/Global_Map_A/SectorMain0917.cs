public class SectorMain0917 : SectorData
{
    public SectorMain0917(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
