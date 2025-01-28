public class SectorMain1010 : SectorData
{
    public SectorMain1010(int x, int y) : base("Main", x, y)
    {
        ADDNPC("Кладовщик");
        HasShop = true; // Указываем, что в этом секторе есть магазин
        Hospital= true; // Указываем, что в этом секторе есть Госпиталь
    }
}
