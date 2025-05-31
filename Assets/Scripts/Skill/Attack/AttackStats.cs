using UnityEngine;

public class AttackStats : MonoBehaviour
{
    private AttackStatsScriptableObject attackStats;
    public AttackStatsScriptableObject AtkStats { get => attackStats; set => attackStats = value; }

    [HideInInspector] public float currentDamage;
    [HideInInspector] public float currentPierce;
    [HideInInspector] public float currentMovementSpeed;
    [HideInInspector] public float currentCooldown;
    [HideInInspector] public int currentCount;
    [HideInInspector] public float currentRange;
    [HideInInspector] public float currentLifespan;
    [HideInInspector] public int currentLevel;
    [HideInInspector] public float currentSpawnRange;
    [HideInInspector] public float currentSpread;

    void Start()
    {
        currentMovementSpeed = attackStats.AttackMovementSpeed;
        currentPierce = attackStats.AttackPierce;
        currentDamage = attackStats.AttackDamage;
        currentCooldown = 0f;
        currentRange = attackStats.AttackRange;
        currentLifespan = attackStats.AttackLifespan;
        currentCount = attackStats.AttackCount;
        currentSpawnRange = attackStats.AttackSpawnRange;
        currentSpread = attackStats.AttackSpread;
        currentLevel = 1;
    }

    void Update()
    {
        if (CanAttack())
        {
            LaunchAttack();
        }
    }

    private bool CanAttack()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            ResetCooldown();
            return true;
        }
        return false;
    }

    private void ResetCooldown()
    {
        currentCooldown = attackStats.AttackCooldown;
    }

    private void LaunchAttack()
    {
        attackStats.SpawnBehavior.SpawnProjectiles(this);
    }
}