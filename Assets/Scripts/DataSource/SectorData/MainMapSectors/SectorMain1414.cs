public class SectorMain1414 : SectorData
{
    public SectorMain1414(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
