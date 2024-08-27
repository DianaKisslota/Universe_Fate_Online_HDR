using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAttackResolver
{
    public AttackResult ResolveRangeAttack(IAttacker attacker, ITarget target, int numberAttack = 1);
    public AttackResult ResolveMeleeAttack(IAttacker attacker, ITarget target, int numberAttack = 1);
}

