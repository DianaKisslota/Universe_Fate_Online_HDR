public class SectorMain0608 : SectorData
{
    public SectorMain0608(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

