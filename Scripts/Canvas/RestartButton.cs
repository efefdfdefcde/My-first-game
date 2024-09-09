using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public static Action restartEvent;

    public void Restart()
    {
        restartEvent.Invoke();
        
    }


}
