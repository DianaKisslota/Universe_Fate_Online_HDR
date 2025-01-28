public class SectorMain1009 : SectorData
{
    public SectorMain1009(int x, int y) : base("Main", x, y)
    {
        Arena = true; // Указываем, что в этом секторе есть арена
        Warehouse = true; // Указываем, что в этом секторе есть склад
    }
}

