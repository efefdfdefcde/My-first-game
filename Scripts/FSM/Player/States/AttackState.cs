using Assets.NewScripts.FSM.Player.Helpers;
using System;
using UnityEngine;



public class AttackState : State
{
    private PlayerView _playerView;
    private Transform _attackPoint;
    private float _attackArea;
    private LayerMask _enemyMask;
    private float _damage;
    private StaminaPool _pool;
    private bool _inHide;
    private PlayerAudio _audio;

    
    public static Action<bool> _attackEndAction; 

    public AttackState(PlayerView playerView, Transform attackPoint, float attackArea, LayerMask enemyMask, float damage, StaminaPool staminaPool, PlayerAudio audio)
    {
        _playerView = playerView;
        _attackPoint = attackPoint;
        _attackArea = attackArea;
        _enemyMask = enemyMask;
        _damage = damage;
        _pool = staminaPool;
        _audio = audio;
        AttackHelper._dealDamageAction += DealDamage;
        ControlKeys._attackAction += Attack;
        StealsManager._inHideAction += HideSwitcher;
    }

  

    public override void Exit() 
    {
        _attackEndAction?.Invoke(false);
        _playerView.Idle();
    }

   

    public void Attack()
    {
        if (!_inHide && _pool.AttackChecker())
        {
            _playerView.Attack();
        }
       
    }

    private void DealDamage()
    {
        var targets = Physics2D.OverlapCircleAll(_attackPoint.position, _attackArea, _enemyMask);
        if(targets.Length == 0)
        {
            _audio.MissAttack();
        }
        else
        {
            foreach (var target in targets)
            {
                if (target.CompareTag("Enemy"))
                {
                    try
                    {
                        target.GetComponent<Character>().TakeDamage(_damage);
                    }
                    catch { NullReferenceException ex; }


                }
                else
                {
                    try
                    {
                        target.GetComponent<BreakableObject>().Take_Damage();
                    }
                    catch { NullReferenceException ex; }
                }
            }
        }
       
        _pool.Attack();
        
    }

    private void HideSwitcher(bool hide)
    {
        _inHide = hide;
    }

    public void Description()
    {
        AttackHelper._dealDamageAction -= DealDamage;
        
    }
}
