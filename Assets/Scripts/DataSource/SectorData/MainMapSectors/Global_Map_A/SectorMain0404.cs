public class SectorMain0404 : SectorData
{
    public SectorMain0404(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
