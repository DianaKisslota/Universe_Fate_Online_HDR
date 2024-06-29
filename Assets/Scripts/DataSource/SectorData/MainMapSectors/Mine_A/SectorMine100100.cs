public class SectorMine100100 : SectorData
{
    public SectorMine100100(int x, int y) : base("Mine", x, y)
    {
        ADDNPC("Выход");
        TransferTo = new TransferInfo("Global_map_HD", "Main1413", "Выйти из шахты");
    }
}
