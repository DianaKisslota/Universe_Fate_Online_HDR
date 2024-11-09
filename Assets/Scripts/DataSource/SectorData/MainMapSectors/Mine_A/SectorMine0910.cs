public class SectorMine0910 : SectorData
{
    public SectorMine0910(int x, int y) : base("Mine", x, y)
    {
        AddMonster(new EntitySpawner(typeof(MineBot), 1, 3));
    }
}
