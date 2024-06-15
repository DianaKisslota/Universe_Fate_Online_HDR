public class PM : RangeWeapon
{
    public PM()
    {
        Name = "ПМ";
        WeaponType = WeaponType.Pistol;
        Caliber = Caliber.bullet9x18;
        AmmoCapacity = 8;
        Weight = 0.73f;
        Volume = 0.3f;
        AddSkill(SkillType.Pistol, 1);
    }
}

