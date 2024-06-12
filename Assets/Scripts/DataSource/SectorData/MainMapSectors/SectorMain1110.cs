public class SectorMain1110 : SectorData
{
    public SectorMain1110(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
        AddItem(typeof(PM));
        
        var cabinet = new Cabinet();
        cabinet.AddItem(new AK47());
        AddStaticContainer(cabinet);

        var biohazzardCase = new BiohazzardCase();
        biohazzardCase.AddItem(new DogMeat());
        AddSmallContainer(biohazzardCase);
    }
}
