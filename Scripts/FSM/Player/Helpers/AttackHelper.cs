using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHelper : MonoBehaviour
{
    private Animator Animator;

    public static Action _dealDamageAction;
    public static Action<bool> _attackEnd;
  

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    //AnimationCall
    private void DealDamageAction()         
    {
        _dealDamageAction?.Invoke();
       
    }

    private void AttackEnd()
    {
        Animator.Play("Player_Idle");
        _attackEnd.Invoke(false);
       
    }
}
