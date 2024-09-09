using Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpikes : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(_damage);
        }
    }
}
