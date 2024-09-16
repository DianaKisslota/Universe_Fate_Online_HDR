using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class Weapon : Item
{
    public List<Skill> SkillsNeeded {  get; private set; } = new List<Skill>();
    public WeaponType WeaponType { get; set; }

    private Dictionary<FireMode, int> AttackCosts = new Dictionary<FireMode, int>();
    public int AttackCost(FireMode fireMode = FireMode.Undefined)
    {
        if (AttackCosts.TryGetValue(fireMode, out int cost))
            return cost;
        else
        {
            Debug.LogError("Неверный режим атаки" + fireMode);
            return -1;
        }

    }

    protected void AddAttackCost(FireMode fireMode, int cost)
    {
        AttackCosts.Add(fireMode, cost);
    }

    public void AddSkill(SkillType skill, int skillLevel)
    {
        SkillsNeeded.Add(new Skill() { Type = skill, Level = skillLevel });
    }
}

