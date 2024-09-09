using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void TakeDamage(float damage)
    {
        _player.TakeDamage(damage);
    }
}
