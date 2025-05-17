public class EnemyStats : LivingEntityStats
{
    private EnemyStatsScriptableObject enemStats;
    public EnemyStatsScriptableObject EnemStats {get => enemStats;}

    private DamageIndicator damageIndicator;
    private LootTable lootTable;

    protected override void Awake()
    {
        base.Awake();
        enemStats = (EnemyStatsScriptableObject) stats;
        damageIndicator = GetComponent<DamageIndicator>();
        lootTable = GetComponent<LootTable>();
    }

    public void TakeDamage(AttackData attackData)
    {
        // need to take into account for elemental weakness/resistance
        float actualDamage = attackData.totalDamage * GameWorld.Instance.GetElementalDamageModifier(attackData.element, enemStats.EnemyType);
        damageIndicator.IsCrit = attackData.isCrit;
        TakeDamage(actualDamage);
    }

    protected override void AdjustHealth(float value)
    {
        base.AdjustHealth(value);
        damageIndicator.ShowDamage(value);
    }

    protected override void Kill()
    {
        Destroy(gameObject);
        lootTable.DropLoot();
    }
}
