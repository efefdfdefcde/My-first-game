using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pause;

    private AudioSource _source => GetComponent<AudioSource>();

    public static Action<bool> _cursorAction;

    private void Update()
    {
       PauseCheck();
    }

    private void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        _pause.SetActive(true);
        Time.timeScale = 0f;
        _cursorAction?.Invoke(true);
    }

    public void Resume()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
        _source.Play();
        _cursorAction?.Invoke(false);
    }
}
