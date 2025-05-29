using UnityEngine;

[CreateAssetMenu(fileName = "TowardsMouseSpawnBehavior", menuName = "ScriptableObjects/AttackSpawnBehavior/TowardsMouseSpawnBehavior")]
public class TowardsMouseSpawnBehavior : SpawnBehavior
{
    public override void SpawnProjectiles(AttackStats attackStats)
    {
        float angleStep = attackStats.currentSpread;
        float totalSpread = angleStep * (attackStats.currentCount - 1);
        float startOffset = -totalSpread / 2f;

        Vector2 center = PlayerManager.Instance.transform.position;
        Vector2 mouse = (GameWorld.Instance.GetMousePosition() - center).normalized;

        for (int i = 0; i < attackStats.currentCount; i++)
        {
            float angle = startOffset + i * angleStep;
            Vector2 rotatedDir = VectorUtil.RotateVector(mouse, angle);

            GameObject proj = Instantiate(attackStats.AtkStats.SkillPrefab, center + rotatedDir * attackStats.currentSpawnRange, Quaternion.identity);
            MovementBehavior movement = proj.GetComponent<MovementBehavior>();
            movement?.Initialize(rotatedDir, attackStats);
        }
    }
}
