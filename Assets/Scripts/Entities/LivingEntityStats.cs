using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntityStats : MonoBehaviour
{
    [SerializeField] protected LivingEntityStatsScriptableObject stats;

    // iframe
    [SerializeField] private ImmunityFlash immunityFlash;
    [HideInInspector] public float invincibilityTimer;
    [HideInInspector] public bool isInvincible;
    private Dictionary<string, int> hitCountPerSource;
    private float accumulatedDamage;
    private bool tookDamageThisFrame;


    // current stats
    [HideInInspector] public float currentMaxHealth;
    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentMovementSpeed;
    [HideInInspector] public float currentDamage;
    [HideInInspector] public float currentAttackSpeed;
    [HideInInspector] public float currentDamageFallOff = 0.1f;
    [HideInInspector] public float currentDamageMaxFallOff = 0.4f;


    protected virtual void Awake()
    {
        currentMovementSpeed = stats.MovementSpeed;
        currentDamage = stats.Strength;
        currentMaxHealth = stats.Health;
        currentHealth = stats.Health;
        currentAttackSpeed = stats.AttackSpeed;
        invincibilityTimer = stats.IFrameDuration;
        isInvincible = false;
        hitCountPerSource = new Dictionary<string, int>();
    }

    private void CheckIFrame()
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
            isInvincible = true;
            invincibilityTimer = stats.IFrameDuration;
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

    public void TakeDamage(float damage, string source)
    {
        if (isInvincible) return;

        // Track number of hits from this source
        if (!hitCountPerSource.ContainsKey(source))
        {
            hitCountPerSource[source] = 1;
        }
        else
        {
            hitCountPerSource[source]++;
        }

        int hitNumber = hitCountPerSource[source];
        float reductionFactor = Mathf.Max(1f - currentDamageFallOff * (hitNumber - 1), currentDamageMaxFallOff);
        float adjustedDamage = damage * reductionFactor;

        accumulatedDamage += adjustedDamage;
        tookDamageThisFrame = true;
    }


    void LateUpdate()
    {
        CheckIFrame();

        if (tookDamageThisFrame)
        {
            AdjustHealth(-accumulatedDamage);
            CheckHealth();

            tookDamageThisFrame = false;
            accumulatedDamage = 0f;
            hitCountPerSource.Clear();
        }
    }

    protected abstract void Kill();
}
