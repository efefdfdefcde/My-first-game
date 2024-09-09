using Assets.NewScripts.FSM.Enemy;
using Assets.Scripts.Data.Necromancer;
using Assets.Scripts.FSM.Necromancer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerControll : EnemyControll
{
    private NecromancerData data;
    private NecromancerAttackState AttackState;
    private NecromancerAudio _audio => GetComponent<NecromancerAudio>();

    protected override void Attack()
    {
        StateMashine.ChangeState(AttackState);
    }

    protected override void Init()
    {
        base.Init();
        data = (NecromancerData)EnemyData;
        AttackState = new NecromancerAttackState(EnemyData.GetAttackCooldown(), EnemyData.Damage, EnemyData.GetAttackPoint()
                , EnemyData.GetAttackZone(), EnemyData.GetPlayerMask(), EnemyData.EnemyView, attackHelper,data.GetPrefab(), data.GetSpawnEffect(), transform, _audio);
        attackState.OnDestroy();

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        AttackState.OnDestroy();
    }
}
