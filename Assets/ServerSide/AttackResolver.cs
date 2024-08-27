using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AttackResolver : IAttackResolver
{
    public AttackResult ResolveMeleeAttack(IAttacker attacker, ITarget target, int numberAttack = 1)
    {
        var attackResult = new AttackResult();
        for (int i = 0; i < numberAttack; i++)
        {
            Debug.Log("Шанс попасть " + attacker.BaseHitChance);
            var random = Random.Range(1, 101) / 100f;
            var ishit = random >= attacker.BaseHitChance;
            if (ishit)
            {
                attackResult.DamageInflicted += attacker.BaseDamage;
                if (attacker.Weapon is MeleeWeapon meleeWeapon)
                    attackResult.DamageInflicted += meleeWeapon.AddMeleeDamage;
                Debug.Log("Есть пробитие! " + attackResult.DamageInflicted + " урона.");
            }
            else
                Debug.Log("Промах!");
        }
        return attackResult;
    }

    public AttackResult ResolveRangeAttack(IAttacker attacker, ITarget target, int numberAttack = 1)
    {
        var attackResult = new AttackResult();
        for (int i = 0; i < numberAttack; i++)
        {
            Debug.Log("Шанс попасть " + attacker.BaseHitChance);
            var random = Random.Range(1, 101) / 100f;
            var ishit = random >= attacker.BaseHitChance;
            Debug.Log("Выпало " + random + " на попадание");
            if (ishit)
            {
                attackResult.DamageInflicted += attacker.BaseDamage;
                Debug.Log("Есть пробитие! " + attackResult.DamageInflicted + " урона.");
            }
            else
                Debug.Log("Промах!");
        }

        return attackResult;
    }
}

