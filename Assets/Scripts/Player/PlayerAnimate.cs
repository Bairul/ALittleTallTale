using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public int horizontal;
    [HideInInspector] public int vertical;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetInteger("Vertical", vertical);
        animator.SetInteger("Horizontal", horizontal);
    }
}
