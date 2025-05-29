using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class MovementBehavior : MonoBehaviour
{
    protected AttackData attackData;
    protected Vector2 direction;

    protected abstract void Tick(float deltaTime);

    public void Initialize(Vector2 initialFacingDirection, AttackStats attackStats)
    {
        direction = initialFacingDirection.normalized;
        attackData = new AttackData(attackStats);
    }

    protected virtual void Start()
    {
        if (attackData == null)
        {
            Debug.LogError("Null attack data in " + gameObject.name);
        }
        Destroy(gameObject, attackData.lifespan);
    }

    void FixedUpdate()
    {
        Tick(Time.deltaTime);
    }

    private void ReducePierce()
    {
        attackData.pierce--;

        if (attackData.pierce <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (attackData.pierce > 0 && collider.CompareTag("Enemy"))
        {
            EnemyStats enemy = collider.GetComponentInParent<EnemyStats>();
            enemy.TakeDamage(attackData);
            ReducePierce();
        }
    }
}
