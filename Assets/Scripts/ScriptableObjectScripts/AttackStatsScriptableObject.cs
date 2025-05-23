using UnityEngine;
using UnityEngine.UI;
using static AllEnums;

[CreateAssetMenu(fileName ="AttackStatsScriptableObject", menuName ="ScriptableObjects/Attack")]
public class AttackStatsScriptableObject : SkillStatsScriptableObject
{
    [SerializeField]
    private GameObject skillPrefab;
    public GameObject SkillPrefab { get => skillPrefab; private set => skillPrefab = value; }

    [SerializeField]
    private ElementalType elementalType;
    public ElementalType ElementalType { get => elementalType; private set => elementalType = value; }

    [SerializeField]
    private AttackType attackType;
    public AttackType AttackType { get => attackType; private set => attackType = value; }

    [SerializeField]
    private AttackTargetType attackTargetType;
    public AttackTargetType AttackTargetType { get => attackTargetType; private set => attackTargetType = value; }

    [SerializeField]
    private float attackDamage;
    public float AttackDamage { get => attackDamage; private set => attackDamage = value; }

    [SerializeField]
    private float attackPierce;
    public float AttackPierce { get => attackPierce; private set => attackPierce = value; }

    [SerializeField]
    private float attackMovementSpeed;
    public float AttackMovementSpeed { get => attackMovementSpeed; private set => attackMovementSpeed = value; }

    [SerializeField]
    private float attackRange;
    public float AttackRange { get => attackRange; private set => attackRange = value; }

    [SerializeField]
    private float attackLifespan;
    public float AttackLifespan { get => attackLifespan; private set => attackLifespan = value; }

    [SerializeField]
    private float attackCooldown;
    public float AttackCooldown { get => attackCooldown; private set => attackCooldown = value; }

    [SerializeField]
    private int attackCount;
    public int AttackCount { get => attackCount; private set => attackCount = value; }
}
