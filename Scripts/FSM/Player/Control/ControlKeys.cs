using Assets.FSM;
using System.Collections;
using UnityEngine;
using System;


public class ControlKeys 
{
    private StateMashine _SM;
    private WalkState _WalkState;
    private JumpState _JumpState;
    private AttackState _AttackState;
    private BlockState _BlockState;

    public static Action _jumpAction;
    public static Action _useHealAction;
    public static Action _attackAction;
    public static Action _hideAction;
   

    public ControlKeys(StateMashine stateMashine, WalkState walkState, JumpState jumpState, AttackState attackState, BlockState blockState)
    {
        _SM = stateMashine;
        _WalkState = walkState;
        _JumpState = jumpState;
        _AttackState = attackState;
        _BlockState = blockState;
    }

    private void WalkControll()
    {

        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            _SM.ChangeState(_WalkState);
        }

    }

    private void JumpControll()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _SM.ChangeState(_JumpState);
            _jumpAction?.Invoke();
        }
    }

    private void AttackControll()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _SM.ChangeState(_AttackState);
            _attackAction?.Invoke();
        }

    }

    private void BlockControll()
    {
        if (Input.GetButton("Fire2"))
        {
            _SM.ChangeState(_BlockState);
        }
    }

    private void UseHeal()
    {
        if (Input.GetKeyDown("e"))
        {
            _useHealAction?.Invoke();
        } 
    }

    private void Hide()
    {
        if (Input.GetKeyDown("f"))
        {
            _hideAction?.Invoke();
        }
    }

    public void Controll()
    {
        WalkControll();
        JumpControll();
        AttackControll();
        BlockControll();
        UseHeal();
        Hide();
    }
}
