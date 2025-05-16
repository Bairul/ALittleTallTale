using System.Collections.Generic;
using UnityEngine;
using static AllEnums;

public class GameWorld : MonoBehaviour
{
    // Gamworld singleton
    public static GameWorld Instance { get; private set; }

    // place all skills here
    [SerializeField]
    private AttackStatsScriptableObject[] allAttackSkills;
    public AttackStatsScriptableObject[] AllAttackSkills  { get => allAttackSkills ; private set => allAttackSkills  = value; }

    [SerializeField]
    private AttributeStatsScriptableObject[] allAttributeSkills;
    public AttributeStatsScriptableObject[] AllAttributeSkills  { get => allAttributeSkills ; private set => allAttributeSkills  = value; }

    // elemental damage bonus
    [Range(0,1)] [SerializeField] private float elementalDamageBonus;

    [Range(0,1)] [SerializeField] private float elementalDamageResist;
    private Dictionary<string, float> elementalDamageTable;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        elementalDamageTable = new Dictionary<string, float>
        {
            { ElementalType.Fire.ToString() + EnemyType.Armored.ToString(), 1f - elementalDamageResist },
            { ElementalType.Fire.ToString() + EnemyType.Flesh.ToString(), 1f + elementalDamageBonus },
            { ElementalType.Fire.ToString() + EnemyType.Flying.ToString(), 1f },

            { ElementalType.Water.ToString() + EnemyType.Armored.ToString(), 1f + elementalDamageBonus / 2f },
            { ElementalType.Water.ToString() + EnemyType.Flesh.ToString(), 1f + elementalDamageBonus / 2f },
            { ElementalType.Water.ToString() + EnemyType.Flying.ToString(), 1f + elementalDamageBonus / 2f },

            { ElementalType.Earth.ToString() + EnemyType.Armored.ToString(), 1f + elementalDamageBonus },
            { ElementalType.Earth.ToString() + EnemyType.Flesh.ToString(), 1f },
            { ElementalType.Earth.ToString() + EnemyType.Flying.ToString(), 1f - elementalDamageResist },

            { ElementalType.Wind.ToString() + EnemyType.Armored.ToString(), 1f },
            { ElementalType.Wind.ToString() + EnemyType.Flesh.ToString(), 1f - elementalDamageResist },
            { ElementalType.Wind.ToString() + EnemyType.Flying.ToString(), 1f + elementalDamageBonus }
        };
    }

    public float GetElementalDamageModifier(ElementalType elementalType, EnemyType enemyType)
    {
        if (elementalDamageTable.TryGetValue(elementalType.ToString() + enemyType.ToString(), out float damageModifier))
        {
            return damageModifier;
        }
        return 1.0f;
    }
}
