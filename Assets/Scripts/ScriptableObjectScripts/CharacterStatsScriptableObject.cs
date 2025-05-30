using System.Collections.Generic;
using UnityEngine;
using static AllEnums;

[CreateAssetMenu(fileName = "CharacterStatsScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterStatsScriptableObject : LivingEntityStatsScriptableObject
{
    [Range(0, 1)]
    [SerializeField]
    private float critRate;
    public float CritRate { get => critRate; private set => critRate = value; }

    [Range(1, 5)]
    [SerializeField]
    private float critDamage;
    public float CritDamage { get => critDamage; private set => critDamage = value; }

    [SerializeField]
    private float magnetRange;
    public float MagnetRange { get => magnetRange; private set => magnetRange = value; }

    [Header("Skills")]
    [SerializeField]
    private ElementalType[] elementalAffinities;
    public ElementalType[] ElementalAffinities { get => elementalAffinities; }

    [Header("Leveling - Min/Max are inclusive")]
    [SerializeField]
    private List<LevelRange> levelRanges;
    public List<LevelRange> LevelRanges { get => levelRanges; }

    [Header("Starting Skills")]
    [SerializeField]
    private SkillStatsScriptableObject basicAttack;
    public SkillStatsScriptableObject BasicAttack { get => basicAttack; private set => basicAttack = value; }
}
