public class SectorMain1205 : SectorData
{
    public SectorMain1205(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
