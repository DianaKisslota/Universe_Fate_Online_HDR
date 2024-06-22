public class SectorMain0610 : SectorData
{
    public SectorMain0610(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

