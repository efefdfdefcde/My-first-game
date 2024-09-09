using System;
using UnityEngine;

public class RestarButtonPause : MonoBehaviour
{
    public static Action _restartEvent;

    public void Restart()
    {
        Time.timeScale = 1f;
        _restartEvent?.Invoke();
        
    }
}
