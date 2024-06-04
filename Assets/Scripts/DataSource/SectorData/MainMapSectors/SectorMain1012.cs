public class SectorMain1012 : SectorData
{
    public SectorMain1012(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
