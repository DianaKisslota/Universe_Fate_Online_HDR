public class SectorMain1308 : SectorData
{
    public SectorMain1308(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
