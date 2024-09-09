using Assets.NewScripts.FSM.Enemy.Helpers;
using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class EnemyAttackState : State
{
    protected float _nextAttackTime;
    protected float _attackCooldown;
    protected float _damage;
    protected Transform _attackPoint;
    protected Vector2 _attacklZone;
    protected LayerMask _playerMask;
    protected EnemyView _enemyView; 
    protected EnemyAttackHelper _enemyAttackHelper;

    public EnemyAttackState(float attackCooldown, float damage, Transform attackPoint, Vector2 attackZone, LayerMask playerMask, EnemyView enemyView,EnemyAttackHelper enemyAttackHelper)
    {
       
        _attackCooldown = attackCooldown;
        _damage = damage;
        _attackPoint = attackPoint;
        _attacklZone = attackZone;
        _playerMask = playerMask;
        _enemyView = enemyView;
        _enemyAttackHelper = enemyAttackHelper;
        _enemyAttackHelper._damageAction += DealDamage;
        
    }

    public override void Enter()
    {
        _enemyView.Idle();
    }

    

    public override void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Time.time >= _nextAttackTime)
        {
            _enemyView.Attack();
            _nextAttackTime = Time.time + _attackCooldown;

        }

    }
    protected virtual void DealDamage()
    {
        Collider2D _foundPlayer = Physics2D.OverlapBox(_attackPoint.position, _attacklZone, 0, _playerMask);
        try
        {
            _foundPlayer.TryGetComponent(out Player player);
            player.TakeDamage(_damage);
        }
        catch { NullReferenceException e; }

        
    }

    public void OnDestroy()
    {
        _enemyAttackHelper._damageAction -= DealDamage;
    }
   
}

