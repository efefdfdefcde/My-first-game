using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Button : MonoBehaviour
{
    [SerializeField] ArrowTrap trap;
    private bool activated;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!activated)
        {
            animator.Play("Activated");
            activated = true;
            trap.Shoot();

        }
    }
}
