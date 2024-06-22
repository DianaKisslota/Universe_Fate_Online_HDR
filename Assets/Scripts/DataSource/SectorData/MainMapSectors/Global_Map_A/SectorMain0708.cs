public class SectorMain0708 : SectorData
{
    public SectorMain0708(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

