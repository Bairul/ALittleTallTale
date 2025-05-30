using UnityEngine;

public class OrbitMovementBehavior : MovementBehavior
{
    private Transform player;
    private float angle;

    protected override void Start()
    {
        base.Start();
        player = PlayerManager.Instance.transform;

        Vector2 flatDir = (Vector2) direction.normalized;
        angle = Mathf.Atan2(flatDir.y, flatDir.x);
    }

    protected override void Tick(float deltaTime)
    {
        angle += attackData.speed * deltaTime;
        Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * attackData.range;
        transform.position = player.position + offset;
    }
}