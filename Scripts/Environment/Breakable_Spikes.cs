using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Spikes : Trap
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            base.OnTriggerEnter2D(collision);
        }
        
    }
}
