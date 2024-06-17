public class SectorMain1509 : SectorData
{
    public SectorMain1509(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
