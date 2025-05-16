using UnityEngine;
using static AllEnums;

public class AttackStats : MonoBehaviour
{
    private AttackStatsScriptableObject attackStats;
    public AttackStatsScriptableObject AtkStats { get => attackStats; set => attackStats = value; }

    [HideInInspector] public float currentDamage;
    [HideInInspector] public float currentPierce;
    [HideInInspector] public float currentMovementSpeed;
    [HideInInspector] public float currentCooldown;
    [HideInInspector] public float currentCount;
    [HideInInspector] public float currentRange;
    [HideInInspector] public float currentLifespan;
    [HideInInspector] public int currentLevel;

    void Start()
    {
        currentMovementSpeed = attackStats.AttackMovementSpeed;
        currentPierce = attackStats.AttackPierce;
        currentDamage = attackStats.AttackDamage;
        currentCooldown = attackStats.AttackCooldown;
        currentRange = attackStats.AttackRange;
        currentLifespan = attackStats.AttackLifespan;
        currentCount = attackStats.AttackCount;
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
        GameObject atk = Instantiate(attackStats.SkillPrefab, transform.position, Quaternion.identity);
        // attach a behavior to the instance
        AttackBehavior ab = attackStats.AttackTargetType switch
        {
            AttackTargetType.Mouse => atk.AddComponent<AimAtMouseBehavior>(),
            AttackTargetType.NearestTargets => null,
            AttackTargetType.RandomTargets => null,
            AttackTargetType.WalkDirection => null,
            AttackTargetType.Other => null,
            _ => null
        };

        ab.AtkData = new AttackData(this, PlayerManager.Instance.Stats);
    }
}
