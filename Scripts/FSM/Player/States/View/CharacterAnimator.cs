using System;
using System.Collections;
using UnityEngine;



public abstract class CharacterAnimator : MonoBehaviour
{

    protected Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    protected void ChangeAnimation(string animation)
    {
        try
        {
            animator.Play(animation);
        }
        catch { NullReferenceException ex; }  

    }

}
