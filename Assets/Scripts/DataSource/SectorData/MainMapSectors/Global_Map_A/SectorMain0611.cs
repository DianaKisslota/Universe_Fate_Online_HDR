public class SectorMain0611 : SectorData
{
    public SectorMain0611(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

