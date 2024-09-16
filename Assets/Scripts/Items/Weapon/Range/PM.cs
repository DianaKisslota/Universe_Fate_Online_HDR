public class PM : RangeWeapon
{
    public PM()
    {
        Name = "ПМ";
        WeaponType = WeaponType.Pistol;
        Caliber = Caliber.bullet9x18;
        AmmoCapacity = 8;
        ReloadCost = 2;
        Weight = 0.73f;
        Volume = 0.3f;
        AddSkill(SkillType.Pistol, 1);
        AddAttackCost(FireMode.SingleShot, 2);
    }
}

