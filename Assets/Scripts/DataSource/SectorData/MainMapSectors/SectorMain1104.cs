public class SectorMain1104 : SectorData
{
    public SectorMain1104(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
