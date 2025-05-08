using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimate : MonoBehaviour
{
    public Animator animator;

    [HideInInspector]
    public int horizontal;
    
    [HideInInspector]
    public bool attack;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Attack", attack);
        animator.SetInteger("Horizontal", horizontal);
    }

    void FinishAttackAnimation() {
        attack = false;
    }
}
