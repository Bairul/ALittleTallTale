using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField]
    protected CollectibleScriptableObject collectibleData;
    public CollectibleScriptableObject CollectibleData {get => collectibleData; set => collectibleData = value;}

    protected abstract void Collect(PlayerStats player);

    public void MoveTowards(Transform other)
    {
        Vector2 direction = (other.position - transform.position).normalized;
        Vector3 vel = collectibleData.PullSpeed * Time.deltaTime * direction;
        transform.position += vel;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Collect(collider2D.gameObject.GetComponentInParent<PlayerStats>());
        }
    }
}