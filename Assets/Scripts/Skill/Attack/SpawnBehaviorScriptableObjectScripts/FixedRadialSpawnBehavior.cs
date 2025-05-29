using UnityEngine;

[CreateAssetMenu(fileName = "FixedRadialSpawnBehavior", menuName = "ScriptableObjects/AttackSpawnBehavior/FixedRadialSpawnBehavior")]
public class FixedRadialSpawnBehavior : SpawnBehavior
{
    public override void SpawnProjectiles(AttackStats attackStats)
    {
        float angleStep = 360f / attackStats.currentCount;
        
        Vector2 center = PlayerManager.Instance.GetPlayerPosition();
        Vector2 right = Vector2.right;

        for (int i = 0; i < attackStats.currentCount; i++)
        {
            float angle = angleStep * i;
            Vector2 rotatedDir = VectorUtil.RotateVector(right, angle);

            GameObject proj = Instantiate(attackStats.AtkStats.SkillPrefab, center + rotatedDir * attackStats.currentSpawnRange, Quaternion.identity);
            MovementBehavior movement = proj.GetComponent<MovementBehavior>();
            movement?.Initialize(rotatedDir, attackStats);
        }
    }
}