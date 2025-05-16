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

    protected override void DamageTaken(AttackData attackData)
    {
        base.DamageTaken(attackData);
        float elementalDamage = attackData.totalDamage * GameWorld.Instance.GetElementalDamageModifier(attackData.element, enemStats.EnemyType);
        DamageTaken(elementalDamage - attackData.totalDamage);
        damageIndicator.ShowDamage(elementalDamage, attackData.isCrit);
    }

    protected override void Kill()
    {
        Destroy(gameObject);
        lootTable.DropLoot();
    }
}
