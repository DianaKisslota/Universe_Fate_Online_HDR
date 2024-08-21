public class SectorMain1110 : SectorData
{
    public SectorMain1110(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
        AddItem(typeof(PM));
        AddItem(typeof(AK47));

        var cabinet = new Cabinet();
        cabinet.AddItem(new UMP45());
        cabinet.AddItem(new Ammo045ACP(), 25);
        AddStaticContainer(cabinet);

        var biohazzardCase = new BiohazzardCase();
        biohazzardCase.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase);

        var biohazzardCase1 = new BiohazzardCase();
        biohazzardCase1.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase1);

        var biohazzardCase2 = new BiohazzardCase();
        biohazzardCase2.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase2);

        var biohazzardCase3 = new BiohazzardCase();
        biohazzardCase3.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase3);

        var biohazzardCase4 = new BiohazzardCase();
        biohazzardCase4.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase4);

        var biohazzardCase5 = new BiohazzardCase();
        biohazzardCase5.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase5);

        var biohazzardCase6 = new BiohazzardCase();
        biohazzardCase6.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase6);
    }
}
