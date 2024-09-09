using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    public delegate void PlayerDeath();
    public static event PlayerDeath _playerDeathEvent;

    private void OnDeath()
    {
         _playerDeathEvent?.Invoke(); 
       
    }
}
