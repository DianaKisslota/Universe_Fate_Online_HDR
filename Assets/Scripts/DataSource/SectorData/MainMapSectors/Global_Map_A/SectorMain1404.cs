public class SectorMain1404 : SectorData
{
    public SectorMain1404(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
