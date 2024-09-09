using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKicker : MonoBehaviour
{
    [SerializeField] private float _kickRadius;
    [SerializeField] private LayerMask _bulletMask;
    [SerializeField] private Transform _attackPoint;

    private void Update()
    {
        Kick();
    }

    private void Kick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Physics2D.OverlapCircle(_attackPoint.position, _kickRadius, _bulletMask);
            if (bullet)
            {
                bullet.TryGetComponent(out Bullet bullet1 );
                bullet1.ChangeDirrection();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _kickRadius);
    }
}
