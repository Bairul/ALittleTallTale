using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : ActiveStats
{
    private EnemyStatsScriptableObject enemStats;
    public EnemyStatsScriptableObject EnemStats {get => enemStats;}

    protected override void Awake()
    {
        base.Awake();
        enemStats = (EnemyStatsScriptableObject) stats;
    }

    // public void TakeDamage(AttackData attackData) 
    // {
    //     float damage = attackData.GetTotalDamage();
    //     damageIndicator.isCrit = damage > attackData.damage;

    //     damage *= GameWorld.Instance.GetElementalDamageModifier(attackData.element, baseStats.EnemyType);
    //     TakeDamage(damage);
    // }

    // protected override void DamageTaken(float damage)
    // {
    //     base.DamageTaken(damage);
    //     damageIndicator.ShowDamage(damage);
    // }

    protected override void Kill()
    {
        Destroy(gameObject);
    }
}
