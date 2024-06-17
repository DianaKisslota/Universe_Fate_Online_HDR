public class SectorMain1504 : SectorData
{
    public SectorMain1504(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
