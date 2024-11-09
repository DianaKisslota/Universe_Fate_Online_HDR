public class MineBot : Mob
{
    public MineBot()
    {
        Name = "Дрон копатель";
        Description = "Добывающий дрон пришельцев. Его оборудование с одинаковым успехом добывает руду и расчленяет конкурентов по опасному юизнесу";
        AddLoot(typeof(MetalScrap), 1, 3);
        AddLoot(typeof(IronOre), 1, 3);
    }
    protected override void Init()
    {
        Strength = 4;
        Perception = 6;
        Agility = 7;
        Constitution = 4;
        Intelligence = 5;
        Will = 7;

        GroupID = 1;
        AggressionLevel = 1;

        base.Init();
    }

}

