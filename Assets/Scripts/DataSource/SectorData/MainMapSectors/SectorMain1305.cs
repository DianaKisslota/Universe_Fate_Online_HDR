public class SectorMain1305 : SectorData
{
    public SectorMain1305(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
