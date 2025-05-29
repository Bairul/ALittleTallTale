using UnityEngine;

public abstract class SpawnBehavior : ScriptableObject
{
    public abstract void SpawnProjectiles(AttackStats attackStats);
}
