public class SectorMine1010 : SectorData
{
    public SectorMine1010(int x, int y) : base("Mine", x, y)
    {
        ADDNPC("Выход");
        AddMonster(new EntitySpawner(typeof(Kobold), 3, 5));
        TransferTo = new TransferInfo("Global_map_HD", "Main1413", "Выйти из шахты");
    }
}
