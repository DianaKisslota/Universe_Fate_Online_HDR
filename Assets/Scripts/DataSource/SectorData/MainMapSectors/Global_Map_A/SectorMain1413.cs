public class SectorMain1413 : SectorData
{
    public SectorMain1413(int x, int y) : base("Main", x, y)
    {
        ADDNPC("Шахта");
        TransferTo = new TransferInfo("Mine_A", "Mine1010", "Спуститься в шахту");
    }
}
