public class SectorMain0808 : SectorData
{
    public SectorMain0808(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
