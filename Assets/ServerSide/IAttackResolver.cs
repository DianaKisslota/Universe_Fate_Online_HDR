using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAttackResolver
{
    public AttackResult ResolveAttack(IAttacker attacker, ITarget target, int numberAttack = 1);
}

