using UnityEngine;
using static AllEnums;

[CreateAssetMenu(fileName ="EnemyStatsScriptableObject", menuName ="ScriptableObjects/Enemy")]
public class EnemyStatsScriptableObject : LivingEntityStatsScriptableObject
{
    [SerializeField]
    private EnemyType enemyType;
    public EnemyType EnemyType { get => enemyType; private set => enemyType = value; }
}
