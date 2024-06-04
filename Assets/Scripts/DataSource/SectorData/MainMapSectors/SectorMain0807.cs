public class SectorMain0807 : SectorData
{
    public SectorMain0807(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
