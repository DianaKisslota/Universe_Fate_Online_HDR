public class SectorMain0409 : SectorData
{
    public SectorMain0409(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
