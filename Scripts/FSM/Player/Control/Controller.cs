using Assets.FSM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
  
  
    private StateMashine _SM = new StateMashine();
    private PlayerData _PlayerData;
    private WalkState _WalkState;
    private JumpState _JumpState;
    private AttackState _AttackState;
    private BlockState _BlockState;
    private ControlKeys _ControlKeys;
    private GroudChecker _GroudChecker;
    private StaminaPool _StaminaPool;
    private PlayerAudio _PlayerAudio;


    private void Start()
    {
        _PlayerAudio = GetComponent<PlayerAudio>();
        _StaminaPool = GetComponent<StaminaPool>();
        _PlayerData = GetComponent<PlayerData>();
        _GroudChecker = new GroudChecker(transform,_PlayerData.GetJumpSize(), _PlayerData.GetGround()); 
        StateInitialize();
        _ControlKeys = new ControlKeys(_SM, _WalkState, _JumpState, _AttackState, _BlockState);
        _SM.Initialize(_WalkState);
    }

    private void Update()
    {
        _ControlKeys.Controll();
    }

    private void FixedUpdate()
    {
        _SM.CurrentState.Update();
    }

    private void StateInitialize()
    {
        _WalkState = new WalkState(_PlayerData.PlayerView,_PlayerData.GetSpeed(),transform,_GroudChecker);
        _JumpState = new JumpState(_PlayerData.PlayerView,_PlayerData.GetJumpForce(),_PlayerData.Rigidbody2D, _GroudChecker, _PlayerAudio);
        _AttackState = new AttackState(_PlayerData.PlayerView, _PlayerData.GetAttackPoint(),
            _PlayerData.GetAttackArea(), _PlayerData.GetEnemyMask(), _PlayerData.Damage,_StaminaPool, _PlayerAudio);
        _BlockState = new BlockState(_PlayerData.PlayerView);
    }

    private void OnDestroy()
    {
        _AttackState.Description();
        _JumpState.Description();
    }

    


}
