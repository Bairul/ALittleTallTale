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
        Attribute,
        Elemental,
        Dash,
        Starter
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
