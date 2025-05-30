using UnityEngine;

public class StraightMovementBehavior : MovementBehavior
{
    protected override void Tick(float deltaTime)
    {
        transform.position += attackData.speed * deltaTime * (Vector3) direction;
    }
}