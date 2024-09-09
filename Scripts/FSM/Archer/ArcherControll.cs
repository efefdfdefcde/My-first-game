using Assets.NewScripts.Data.ArcherData;
using Assets.NewScripts.FSM.Enemy;
using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.FSM.Archer
{
    public class ArcherControll : EnemyControll
    {
        private ArcherData _data;
        private ArcherAttackState _attackState;
        private ArcherAudio _audio => GetComponent<ArcherAudio>();


        protected override void Attack()
        {
            StateMashine.ChangeState(_attackState);
        }

        protected override void Init()
        {
            base.Init();
            _data = (ArcherData)EnemyData;
            _attackState = new ArcherAttackState(EnemyData.GetAttackCooldown(), EnemyData.Damage, EnemyData.GetAttackPoint()
                , EnemyData.GetAttackZone(), EnemyData.GetPlayerMask(), EnemyData.EnemyView, _data.GetArrovPrefab(),transform,attackHelper,_audio);
            attackState.OnDestroy();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _attackState.OnDestroy();
        }

    }
}