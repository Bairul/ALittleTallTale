using UnityEngine;

public class AllEnums : MonoBehaviour
{
    public enum ElementalType
    {
        Arcane,
        Fire,
        Water,
        Earth,
        Wind,
    }

    public enum SkillType
    {
        Bloodline,
        Attribue,
        Elemental,
        Starter
    }

    public enum AttackType
    {
        Automatic,
        Active
    }

    public enum AttackTargetType
    {
        Mouse,
        NearestTargets,
        RandomTargets,
        WalkDirection,
        Other
    }

    public enum AttributeType
    {
        Strength,
        Health,
        Speed,
        CritRate,
        CritDamage
    }

    public enum EnemyType
    {
        Flying,
        Armored,
        Flesh
    }

    public enum CollectibleType
    {
        Health,
        Experience,
        Coin,
        Powerup
    }
}
