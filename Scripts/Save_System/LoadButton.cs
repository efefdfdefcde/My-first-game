using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    
    public static Action _loadEvent;

    public void Load()
    {
        _loadEvent.Invoke();
        

    }
}
