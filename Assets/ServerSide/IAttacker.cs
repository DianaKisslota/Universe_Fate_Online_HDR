using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum AttackType
{
    Melee,
    Range
}
public interface IAttacker
{
    public float BaseHitChance {  get;}
    public float BaseDamage {  get; }

}

