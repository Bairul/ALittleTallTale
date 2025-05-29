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
    [HideInInspector] public float currentHealth;
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

    protected virtual void AdjustHealth(float value)
    {
        currentHealth = Mathf.Max(0, Mathf.Min(currentHealth + value, currentMaxHealth));
    }

    public void HealHealth(float amount)
    {
        if (amount > 0) AdjustHealth(amount);
    }

    public void TakeDamage(float damage)
    {
        if (isInvincible) return;

        AdjustHealth(-damage);
        CheckHealth();
    }

    protected abstract void Kill();
}
