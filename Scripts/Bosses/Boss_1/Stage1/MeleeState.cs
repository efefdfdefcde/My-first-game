using Assets.Scripts.Bosses;
using System;
using UnityEngine;

public class MeleeState : State
{
    private int _attackCount;
    private float _damage;
    protected float _nextAttackTime;
    protected float _attackCooldown;
    protected Transform _attackPoint;
    protected Vector2 _attacklZone;
    protected LayerMask _playerMask;
    protected Boss1View Boss1View;

    public MeleeState( float damage,float attackCooldown, Transform attackPoint, Vector2 attacklZone, LayerMask playerMask, Boss1View boss1View)
    {
       
        _damage = damage;
        _attackCooldown = attackCooldown;
        _attackPoint = attackPoint;
        _attacklZone = attacklZone;
        _playerMask = playerMask;
        Boss1View = boss1View;
        Boss1AttackHelper._damageType += DealDamage;
    }

    public override void Enter()
    {
        Boss1View.Idle();
    }

    public override void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + _attackCooldown;
            _attackCount++;
            if(_attackCount == 3)
            {
                _attackCount = 0;
                Boss1View.HeavyAttack();
            }
            else { Boss1View.Attack();}
        }
    }

    private void DealDamage(bool isHeavy)
    {
        Collider2D _foundPlayer = Physics2D.OverlapBox(_attackPoint.position, _attacklZone, 0, _playerMask);
        try
        {
            _foundPlayer.TryGetComponent(out Player player);
            if (isHeavy)
            {
                player.TakeDamage(_damage * 2);
            }
            else { player.TakeDamage(_damage); }
            
        }
        catch { NullReferenceException e; }
    }

    public void OnDisable()
    {
        Boss1AttackHelper._damageType -= DealDamage;
    }

    
}
