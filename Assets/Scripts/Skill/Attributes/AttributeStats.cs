using UnityEngine;
using static AllEnums;

public class AttributeStats : MonoBehaviour
{
    private AttributeStatsScriptableObject attributeStats;
    public AttributeStatsScriptableObject AttriStats { get => attributeStats; set => attributeStats = value; }

    private PlayerStats playerStats;
    public PlayerStats PlayerStats { get => playerStats; set => playerStats = value; }

    void Start()
    {
        ApplyModifier();
    }

    private void ApplyModifier()
    {
        float modifier = 1 + attributeStats.Multiplier;

        switch (attributeStats.AttributeType)
        {
            case AttributeType.Strength: playerStats.currentDamage *= modifier;     break;
            case AttributeType.Health: ApplyHealthModifier(modifier);               break;
            case AttributeType.Speed: playerStats.currentMovementSpeed *= modifier; break;
            case AttributeType.CritDamage: playerStats.currentCritDmg *= modifier;  break;
            case AttributeType.CritRate: playerStats.currentCritRate *= modifier;   break;
            default: break;
        }
    }

    private void ApplyHealthModifier(float modifier)
    {
        float healthPercentage = playerStats.currentHealth / playerStats.currentMaxHealth;
        playerStats.currentMaxHealth *= modifier;
        playerStats.currentHealth = playerStats.currentMaxHealth * healthPercentage;
    }
}
