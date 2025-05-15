using UnityEngine;

public class AimAtMouseBehavior : AttackBehavior
{
    public float speed = 10f;

    private Vector3 direction;

    new void Start()
    {
        base.Start();
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;
        direction = (mouseWorld - transform.position).normalized;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }
}