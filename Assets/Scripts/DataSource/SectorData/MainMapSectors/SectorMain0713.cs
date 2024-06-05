public class SectorMain0713 : SectorData
{
    public SectorMain0713(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
