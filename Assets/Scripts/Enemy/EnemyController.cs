using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyStats))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyAnimate animate;

    private Rigidbody2D rgbd2d;
    private EnemyStats enemyStats;

    private Vector2 mvt;
    private bool canAttack;

    void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        enemyStats = GetComponent<EnemyStats>();
    }

    void Start()
    {
        canAttack = true;
    }

    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (canAttack && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Attack(collision.gameObject.GetComponent<PlayerStats>()));
        }
    }

    private IEnumerator Attack(PlayerStats player)
    {
        animate.attack = true;
        canAttack = false;
        player.TakeDamage(enemyStats.currentDamage);

        yield return new WaitForSeconds(enemyStats.currentAttackSpeed);
        canAttack = true;
    }
}
