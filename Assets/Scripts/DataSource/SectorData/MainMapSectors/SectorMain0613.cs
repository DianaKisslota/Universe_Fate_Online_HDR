public class SectorMain0613 : SectorData
{
    public SectorMain0613(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}

