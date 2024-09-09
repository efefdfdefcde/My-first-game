using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Switch : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Switch_Idle()
    {
        animator.Play("Player_Idle");

    }
}
