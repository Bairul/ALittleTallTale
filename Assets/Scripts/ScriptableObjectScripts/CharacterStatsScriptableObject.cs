using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterStatsScriptableObject", menuName ="ScriptableObjects/Character")]
public class CharacterStatsScriptableObject : LivingEntityStatsScriptableObject
{
    [Range(0,1)]
    [SerializeField]
    private float critRate;
    public float CritRate { get => critRate; private set => critRate = value; }

    [SerializeField]
    private float critDamage;
    public float CritDamage { get => critDamage; private set => critDamage = value; }

    [SerializeField]
    private float magnetRange;
    public float MagnetRange { get => magnetRange; private set => magnetRange = value; }

    [Header("Leveling")]
    [SerializeField]
    private int maxLevel;
    public int MaxLevel {get => maxLevel; }

    [SerializeField]
    private List<LevelRange> levelRanges;
    public List<LevelRange> LevelRanges { get => levelRanges; }

    // [Header("Skills")]
    // [SerializeField]
    // private ElementalType[] elementalAffinities;
    // public ElementalType[] ElementalAffinities { get => elementalAffinities; }
}
