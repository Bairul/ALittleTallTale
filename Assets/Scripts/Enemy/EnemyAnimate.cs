using UnityEngine;

public class EnemyAnimate : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    [HideInInspector] public int horizontal;

    [HideInInspector] public int vertical;
    
    [HideInInspector] public bool attack;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetInteger("Horizontal", horizontal);
        animator.SetInteger("Vertical", vertical);
        animator.SetBool("Attack", attack);
    }

    // use in animation events
    void FinishAttackAnimation() {
        attack = false;
    }
}
