public class SectorMain1515 : SectorData
{
    public SectorMain1515(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
