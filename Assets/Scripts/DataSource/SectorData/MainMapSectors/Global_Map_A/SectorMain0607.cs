public class SectorMain0607 : SectorData
{
    public SectorMain0607(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

