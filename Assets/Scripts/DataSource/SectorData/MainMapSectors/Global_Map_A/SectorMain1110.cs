public class SectorMain1110 : SectorData
{
    public SectorMain1110(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 5, 5));
        AddItem(typeof(PM));
        AddItem(typeof(AK47));

        var cabinet = new Cabinet();
        cabinet.AddItem(new AK47());
        AddStaticContainer(cabinet);

        var biohazzardCase = new BiohazzardCase();
        biohazzardCase.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase);
    }
}
