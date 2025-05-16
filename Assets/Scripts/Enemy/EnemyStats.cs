public class EnemyStats : LivingEntityStats
{
    private EnemyStatsScriptableObject enemStats;
    public EnemyStatsScriptableObject EnemStats {get => enemStats;}

    private DamageIndicator damageIndicator;

    protected override void Awake()
    {
        base.Awake();
        enemStats = (EnemyStatsScriptableObject) stats;
        damageIndicator = GetComponent<DamageIndicator>();
    }

    public void TakeDamage(AttackData attackData) 
    {
        float damage = attackData.totalDamage * GameWorld.Instance.GetElementalDamageModifier(attackData.element, enemStats.EnemyType);
        TakeDamage(damage);
        damageIndicator.ShowDamage(damage, attackData.isCrit);
    }

    protected override void Kill()
    {
        Destroy(gameObject);
    }
}
