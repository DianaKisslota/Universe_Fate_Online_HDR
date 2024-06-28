using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AttackResolver : IAttackResolver
{
    public AttackResult ResolveAttack(IAttacker attacker, ITarget target, int numberAttack = 1)
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
                Debug.Log("Есть пробитие! " + attacker.BaseDamage + " урона.");
                attackResult.DamageInflicted += attacker.BaseDamage;
            }
            else
                Debug.Log("Промах!");


        }

        return attackResult;
    }
}

