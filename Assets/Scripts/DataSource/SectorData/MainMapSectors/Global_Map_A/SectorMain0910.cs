﻿public class SectorMain0910 : SectorData
{
    public SectorMain0910(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
        AddBattleScene("BattleScene_Road_1");
    }
}

