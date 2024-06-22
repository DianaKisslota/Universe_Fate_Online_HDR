public class SectorMain0606 : SectorData
{
    public SectorMain0606(int x, int y) : base("Main", x, y)
    {
    AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}

