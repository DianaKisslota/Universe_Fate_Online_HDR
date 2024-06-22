public class SectorMain1108 : SectorData
{
    public SectorMain1108(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
