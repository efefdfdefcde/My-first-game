using Assets.Scripts;
using System.Collections;
using UnityEngine;



public class EnemyIdleState : State
{
    private EnemyView _enemyView;

    public EnemyIdleState(EnemyView enemyView)
    {
        _enemyView = enemyView;
    }   

    public override void Enter()
    {
        _enemyView.Idle();
    }

}
