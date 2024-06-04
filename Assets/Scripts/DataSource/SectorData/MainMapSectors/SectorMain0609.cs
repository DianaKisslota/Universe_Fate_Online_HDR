public class SectorMain0609 : SectorData
{
    public SectorMain0609(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

