public class SectorMain1107 : SectorData
{
    public SectorMain1107(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
