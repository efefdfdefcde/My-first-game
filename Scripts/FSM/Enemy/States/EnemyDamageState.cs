using Assets.Scripts;
using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.FSM.Enemy.States
{
    public class EnemyDamageState : State
    {
        private EnemyView EnemyView;

        public EnemyDamageState(EnemyView enemyView)
        {
            EnemyView = enemyView;
        }

        public override void Enter()
        {
            EnemyView.Damage();
        }
    }
}