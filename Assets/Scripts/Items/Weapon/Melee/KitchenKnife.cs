public class KitchenKnife : MeleeWeapon
{
    public KitchenKnife()
    {
        Name = "Кухонный нож";
        WeaponType = WeaponType.Knife;
        Weight = 0.2f;
        Volume = 0.4f;
        AddMeleeDamage = 10;

        AddAttackCost(FireMode.Undefined, 2);
    }
}

