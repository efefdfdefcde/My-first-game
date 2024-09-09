using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Data
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _attackArea;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Vector2 _jumpCheckerSize;

    public PlayerView PlayerView { get; private set; }
   
    public float MaxStamina { get; private set; }

    public Vector2 GetJumpSize()
    {
        return _jumpCheckerSize;
    }

    public float GetJumpForce()
    {
        return _jumpForce;
    }

    public LayerMask GetGround()
    {
        return _ground;
    }
   
    public float GetAttackArea()
    {
        return _attackArea;
    }

    public LayerMask GetEnemyMask()
    {
        return _enemyMask;
    }

    protected override void ChrtInit()
    {
        base.ChrtInit();
        PlayerCharacteristics playerCharacteristics = (PlayerCharacteristics)_characteristics;
        MaxStamina = playerCharacteristics._maxStamina;
    }

    protected override void Init()
    {
        base.Init();
        PlayerView = (PlayerView)CharacterAnimator;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackArea);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _jumpCheckerSize);
    }
}
