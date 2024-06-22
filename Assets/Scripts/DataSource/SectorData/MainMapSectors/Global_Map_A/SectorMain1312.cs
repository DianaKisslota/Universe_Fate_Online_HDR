public class SectorMain1312 : SectorData
{
    public SectorMain1312(int x, int y) : base("Main", x, y)
    {
    AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}

