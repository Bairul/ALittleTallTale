using UnityEngine;

public abstract class AttackBehavior : MonoBehaviour
{
    protected AttackData attackData;
    public AttackData AtkData { get => attackData; set => attackData = value; }

    protected virtual void Start()
    {
        if (attackData == null)
        {
            Debug.LogError("Null attack data in " + gameObject.name);
        }
        Destroy(gameObject, attackData.lifespan);
    }

    protected virtual void ReducePierce() 
    {
        attackData.pierce--;

        if (attackData.pierce <= 0)
        {
            Kill();
        }
    }

    protected virtual void Kill()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (attackData.pierce > 0 && collider.CompareTag("Enemy"))
        {
            EnemyStats enemy = collider.GetComponentInParent<EnemyStats>();
            enemy.TakeDamage(attackData);
            ReducePierce();
        }
    }
}
