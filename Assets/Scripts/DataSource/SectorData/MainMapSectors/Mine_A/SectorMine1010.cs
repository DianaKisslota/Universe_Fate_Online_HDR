public class SectorMine1010 : SectorData
{
    public SectorMine1010(int x, int y) : base("Mine", x, y)
    {
        IsDark = true;
        ADDNPC("Выход");
        AddMonster(new EntitySpawner(typeof(Kobold), 3, 5));
        var mineCar = new MineCar();
        mineCar.AddItem(new IronOre(), 4);
        AddStaticContainer(mineCar);

        var ironOrePile1 = new IronOrePile();
        ironOrePile1.AddItem(new IronOre(), 5);
        AddSmallContainer(ironOrePile1);

        var ironOrePile2 = new IronOrePile();
        ironOrePile2.AddItem(new IronOre(), 4);
        AddSmallContainer(ironOrePile2);

        var ironOrePile3 = new IronOrePile();
        ironOrePile3.AddItem(new IronOre(), 6);
        AddSmallContainer(ironOrePile3);

        TransferTo = new TransferInfo("Global_map_HD", "Main1413", "Выйти из шахты");
    }
}
