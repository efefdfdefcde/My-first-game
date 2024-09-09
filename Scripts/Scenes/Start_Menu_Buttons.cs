using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu_Buttons : MonoBehaviour
{
    private AudioSource _start => GetComponent<AudioSource>();

    public delegate void Load_Delegate();
    public static event Load_Delegate load_event;


    public void Start_Button()
    {
        _start.Play();
        load_event.Invoke();
    }
    public void Quit_Button()
    {
        Application.Quit();
    }
}
