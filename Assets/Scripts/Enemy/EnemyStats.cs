public class EnemyStats : LivingEntityStats
{
    private EnemyStatsScriptableObject enemStats;
    public EnemyStatsScriptableObject EnemStats {get => enemStats;}

    protected override void Awake()
    {
        base.Awake();
        enemStats = (EnemyStatsScriptableObject) stats;
    }

    public void TakeDamage(AttackData attackData) 
    {
        float damage = attackData.totalDamage * GameWorld.Instance.GetElementalDamageModifier(attackData.element, enemStats.EnemyType);
        TakeDamage(damage);
    }

    protected override void DamageTaken(float damage)
    {
        base.DamageTaken(damage);
        // damageIndicator.ShowDamage(damage);
    }

    protected override void Kill()
    {
        Destroy(gameObject);
    }
}
