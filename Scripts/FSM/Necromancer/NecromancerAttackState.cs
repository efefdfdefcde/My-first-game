using Assets.NewScripts.FSM.Enemy.Helpers;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FSM.Necromancer
{
    public class NecromancerAttackState : EnemyAttackState
    {
        private GameObject _enemyPrefab;
        private ParticleSystem _spawnEffect;
        private Transform _transform;
        private NecromancerAudio _audio;

        public NecromancerAttackState(float attackCooldown, float damage, Transform attackPoint, Vector2 attackZone,
            LayerMask playerMask, EnemyView enemyView, EnemyAttackHelper enemyAttackHelper, GameObject enemyPrefab, ParticleSystem spawnEffect, Transform transform, NecromancerAudio audio)
            : base(attackCooldown, damage, attackPoint, attackZone, playerMask, enemyView, enemyAttackHelper)
        {
            _enemyPrefab = enemyPrefab;
            _spawnEffect = spawnEffect;
            _transform = transform;
            _audio = audio;
        }

        protected override void DealDamage()
        {
            _spawnEffect.Play();
            _audio.Spawn();
            GameObject skeleton = Object.Instantiate(_enemyPrefab,_attackPoint.position,Quaternion.identity);
            skeleton.transform.localScale = _transform.localScale;
        }
    }
}