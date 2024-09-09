using System.Collections;
using UnityEngine;
using System;
using Assets.FSM;


public class StaminaPool : MonoBehaviour
{
    [SerializeField] float _spendAttack;
    [SerializeField] float _spendBlock;
    [SerializeField] float _recoverSpeed;

    private float _maxStamina;
    private float _curentStamina;
    private bool _inState;
    private bool _inRecover;
    private bool _inBlock;

    public static Action<bool> _blockCall;
    public Action<bool> _inRecoverAction;
    public Action<float,float> _staminaToUIAction;


    private void Start()
    {
        BlockState._blockStatusAction += StateChange;
        BlockState._blockCheckAction += BlockCheck;
        AttackHelper._attackEnd += StateChange;
        AttackState._attackEndAction += StateChange;
        _maxStamina = GetComponent<PlayerData>().MaxStamina;
        _curentStamina = _maxStamina;
    }

    private void Update()
    {
        StaminaRecover();
        RecoverSwitch();
        Block();
    }

    private void StaminaRecover()
    {
        if (!_inState)
        {
            _curentStamina += _recoverSpeed * Time.deltaTime;
            _curentStamina = Math.Clamp(_curentStamina,0, _maxStamina);
            _staminaToUIAction?.Invoke(_maxStamina, _curentStamina);
        }
    }

    private void RecoverSwitch()
    {
        if (_curentStamina <= 0)
        {
            _inRecover = true;
            _inRecoverAction.Invoke(_inRecover);
        }
        else if (_inRecover && _curentStamina == _maxStamina)
        {
            _inRecover = false;
            _inRecoverAction.Invoke(_inRecover);    
        }
    }

    private void StateChange(bool inState)
    {
        _inState = inState;
        _inBlock = inState;
    }

    public bool AttackChecker()
    {
        if(_spendAttack <= _curentStamina && !_inRecover && !_inState)
        {
            _inState = true;
           
            return true;
        }
        else { return false; }
    }

    public void Attack()
    {
        _curentStamina -= _spendAttack;
        _staminaToUIAction?.Invoke(_maxStamina, _curentStamina);
    }


    private void BlockCheck()
    {
        bool _canBlock;
        if (_curentStamina > 0 && !_inRecover) _canBlock = true;
        else _canBlock = false; 
        _inBlock = _canBlock;
        _inState = _canBlock;
        _blockCall?.Invoke(_canBlock);
    }

    private void Block()
    {
        if (_inBlock)
        {
            _curentStamina -= _spendBlock * Time.deltaTime;
            _staminaToUIAction?.Invoke(_maxStamina, _curentStamina);
        }
       
    }

   
    private void OnDestroy()
    {
        BlockState._blockStatusAction -= StateChange;
        BlockState._blockCheckAction -= BlockCheck;
        AttackHelper._attackEnd -= StateChange;
    }
}
