using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Button loadButton; 
    [SerializeField] private Button restartButton;
    private Animator animator;

    public static Action<bool> _cursorAction;

    private void OnEnable()
    { 
        animator = GetComponent<Animator>();
        DeadPlayer._playerDeathEvent += DeathScreenTrue;
        RestartButton.restartEvent += DeathScreenFalse;
        RestartButton.restartEvent += ButtonsOff;
        SaveManager._onLoad += DeathScreenFalse;
        SaveManager._onLoad += ButtonsOff;
    }

    private void DeathScreenTrue()
    {
        animator.Play("Death_Screen");
        _cursorAction?.Invoke(true);
    }

    private void DeathScreenFalse()
    {
        animator.Play("Death_Screen_False");
        _cursorAction?.Invoke(false);
    }

    private void ButtonsOn()     //animation Invoke
    {
        restartButton.gameObject.SetActive(true);
        loadButton.gameObject.SetActive(true);
       
    }

    private void ButtonsOff()
    {
        restartButton.gameObject.SetActive(false);
        loadButton.gameObject.SetActive(false);
    }


}
