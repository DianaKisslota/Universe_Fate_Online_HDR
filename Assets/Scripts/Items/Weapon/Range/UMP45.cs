using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UMP45 : RangeWeapon
{
    public UMP45()
    {
        Name = "UMP-45";
        WeaponType = WeaponType.SMG;
        Caliber = Caliber.bullet045ACP;
        AmmoCapacity = 25;
        ReloadCost = 3;
        Weight = 2.45f;
        Volume = 5;
        AddSkill(SkillType.SMG, 1);

        ShortBurst = 3;
        LongBurst = 5;

        AddAttackCost(FireMode.SingleShot, 3);
        AddAttackCost(FireMode.ShortBurst, 5);
        AddAttackCost(FireMode.LongBurst, 7);
    }
}

