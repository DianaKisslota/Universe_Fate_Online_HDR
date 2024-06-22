public class SectorMain1417 : SectorData
{
    public SectorMain1417(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
