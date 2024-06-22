public class SectorMain0709 : SectorData
{
    public SectorMain0709(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

