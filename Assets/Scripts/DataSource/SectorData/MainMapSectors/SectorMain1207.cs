public class SectorMain1207 : SectorData
{
    public SectorMain1207(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
