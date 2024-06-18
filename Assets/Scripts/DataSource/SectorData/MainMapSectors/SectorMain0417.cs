public class SectorMain0417 : SectorData
{
    public SectorMain0417(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}

