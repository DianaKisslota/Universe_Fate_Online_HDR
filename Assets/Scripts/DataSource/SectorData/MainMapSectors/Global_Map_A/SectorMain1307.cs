public class SectorMain1307 : SectorData
{
    public SectorMain1307(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
