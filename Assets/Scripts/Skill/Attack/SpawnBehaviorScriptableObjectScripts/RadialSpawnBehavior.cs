using UnityEngine;

[CreateAssetMenu(fileName = "RadialSpawnBehavior", menuName = "ScriptableObjects/AttackSpawnBehavior/RadialSpawnBehavior")]
public class RadialSpawnBehavior : SpawnBehavior
{
    public override void SpawnProjectiles(AttackStats attackStats)
    {
        float angleStep = 360f / attackStats.currentCount;
        
        Vector2 center = PlayerManager.Instance.GetPlayerPosition();
        Vector2 mouse = (GameWorld.Instance.GetMousePosition() - center).normalized;

        for (int i = 0; i < attackStats.currentCount; i++)
        {
            float angle = angleStep * i;
            Vector2 rotatedDir = VectorUtil.RotateVector(mouse, angle);

            GameObject proj = Instantiate(attackStats.AtkStats.SkillPrefab, center + rotatedDir * attackStats.currentSpawnRange, Quaternion.identity);
            MovementBehavior movement = proj.GetComponent<MovementBehavior>();
            movement?.Initialize(rotatedDir, attackStats);
        }
    }
}
