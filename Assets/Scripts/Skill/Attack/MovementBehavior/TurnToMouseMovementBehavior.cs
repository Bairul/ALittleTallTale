using UnityEngine;

public class TurnToMouseMovementBehavior : MovementBehavior
{
    private Vector2 turnVector;

    protected override void Start()
    {
        base.Start();
        turnVector = (GameWorld.Instance.GetMousePosition() - (Vector2) transform.position).normalized;
    }

    protected override void Tick(float deltaTime)
    {
        direction += turnVector;
        direction.Normalize();
        transform.position += attackData.speed * deltaTime * (Vector3) direction;
    }
}
