using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public  class RangeAttackData : AttackData
{
    public int ShotNumber {  get; set; }
    public int PossibleShotNumber {  get; set; }
    public Type AmmoType { get; set; }
    public Type WeaponType { get; set; }

}

