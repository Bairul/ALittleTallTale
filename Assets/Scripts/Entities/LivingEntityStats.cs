using UnityEngine;

public abstract class LivingEntityStats : MonoBehaviour
{
    [SerializeField] protected LivingEntityStatsScriptableObject stats;

    // iframe
    [SerializeField] private ImmunityFlash immunityFlash;
    [HideInInspector] public float invincibilityTimer;
    [HideInInspector] public bool isInvincible;

    // current stats
    [HideInInspector] public float currentMaxHealth;
    public float currentHealth;
    [HideInInspector] public float currentMovementSpeed;
    public float currentDamage;
    [HideInInspector] public float currentAttackSpeed;
    

    protected virtual void Awake()
    {
        currentMovementSpeed = stats.MovementSpeed;
        currentDamage = stats.Strength;
        currentMaxHealth = stats.Health;
        currentHealth = stats.Health;
        currentAttackSpeed = stats.AttackSpeed;
        invincibilityTimer = stats.IFrameDuration;
        isInvincible = false;
    }

    public void CheckIFrame()
    {
        if (!isInvincible) return;

        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else
        {
            isInvincible = false;
        }
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0) 
        {
            Kill();
        }
        else
        {
            invincibilityTimer = stats.IFrameDuration;
            isInvincible = true;
            immunityFlash.Flash(stats.IFrameDuration);
        }
    }

    public void TakeDamage(float damage) 
    {
        if (isInvincible) return;
        
        DamageTaken(damage);
        CheckHealth();
    }

    public void TakeDamage(AttackData attackData) 
    {
        if (isInvincible) return;
        
        DamageTaken(attackData);
        CheckHealth();
    }

    protected virtual void DamageTaken(float damage)
    {
        currentHealth -= damage;
    }

    protected virtual void DamageTaken(AttackData attackData)
    {
        currentHealth -= attackData.totalDamage;
    }

    protected abstract void Kill();
}
