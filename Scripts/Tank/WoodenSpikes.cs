using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenSpikes : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private Vector2 _damageZone;

    private float _curentTime;
    private Animator _animator;
   
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

   
    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(Time.time >= _curentTime)
        {
            _curentTime = Time.time + _cooldown;
            _animator.Play("Attack");
        }
    }

    private void DealDamage()
    {
        Collider2D player = Physics2D.BoxCast(transform.position, _damageZone, 0,Vector2.up,0,_playerMask).collider;
        if(player != null)
        {
            Character character = player.GetComponent<Character>();
            character.TakeDamage(_damage);
        }
        _animator.Play("Null");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _damageZone);
    }
}
