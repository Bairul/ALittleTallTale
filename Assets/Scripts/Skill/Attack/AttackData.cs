using UnityEngine;
using static AllEnums;

public class AttackData
{
    public string name;
    public ElementalType element;
    public float rawDamage;
    public float totalDamage;
    public float critDmg;
    public float critRate;
    public float pierce;
    public float speed;
    public float lifespan;
    public float range;
    public bool isCrit;

    public AttackData(AttackStats attackStats)
    {
        PlayerStats playerStats = PlayerManager.Instance.Stats;
        
        rawDamage = playerStats.currentDamage + attackStats.currentDamage;
        critRate = playerStats.currentCritRate;
        critDmg = playerStats.currentCritDmg;
        totalDamage = rawDamage * (Random.value < critRate ? critDmg : 1); // crit chance already set
        isCrit = totalDamage > rawDamage;

        name = attackStats.AtkStats.SkillName;
        element = attackStats.AtkStats.ElementalType;
        pierce = attackStats.currentPierce;
        speed = attackStats.currentPierce;
        speed = attackStats.currentMovementSpeed;
        lifespan = attackStats.currentLifespan;
        range = attackStats.currentRange;
    }
}