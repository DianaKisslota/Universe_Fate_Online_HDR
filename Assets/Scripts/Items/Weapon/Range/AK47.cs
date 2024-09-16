public class AK47 : RangeWeapon
{
    public AK47()
    {
        Name = "АК-47";
        WeaponType = WeaponType.AssaultRifle;
        Caliber = Caliber.bullet762x39;
        AmmoCapacity = 30;
        ReloadCost = 4;
        Weight = 3.3f;
        Volume = 10;
        AddSkill(SkillType.AssaultRifle, 1);

        ShortBurst = 3;
        LongBurst = 5;

        AddAttackCost(FireMode.SingleShot, 3);
        AddAttackCost(FireMode.ShortBurst, 6);
        AddAttackCost(FireMode.LongBurst, 9);
    }
}

