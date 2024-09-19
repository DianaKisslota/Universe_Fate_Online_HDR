public class SectorMain1111 : SectorData
{
    public SectorMain1111(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 2, 4));
        AddBattleScene("BattleScene_forest_1");
        AddBattleScene("BattleScene_forest_2");
    }
}
