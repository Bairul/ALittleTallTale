using UnityEngine;

public abstract class ActiveStats : MonoBehaviour
{
    [SerializeField] protected StatsScriptableObject stats;

    // iframe
    [SerializeField] private ImmunityFlash immunityFlash;
    [HideInInspector] public float invincibilityTimer;
    [HideInInspector] public bool isInvincible;

    // current stats (make sure to hide in inspector later)
    [HideInInspector] public float currentMaxHealth;
    public float currentHealth;
    [HideInInspector] public float currentMovementSpeed;
    [HideInInspector] public float currentDamage;
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

    public void TakeDamage(float damage) 
    {
        if (isInvincible) return;
        
        DamageTaken(damage);

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

    protected virtual void DamageTaken(float damage)
    {
        currentHealth -= damage;
    }

    protected abstract void Kill();
}
