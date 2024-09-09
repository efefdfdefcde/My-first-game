using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] protected float damage = float.MaxValue;
    protected void Kill(Collider2D collision)
    {
        try
        {
            collision.TryGetComponent(out Character character);
            character.TakeDamage(damage);
        }
        catch { NullReferenceException e; }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Kill(collision);
    }
}
