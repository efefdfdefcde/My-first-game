using Assets.NewScripts.FSM.Enemy.Helpers;
using Assets.Scripts;
using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.FSM.Archer
{
    public class ArcherAttackState : EnemyAttackState
    {
        private GameObject _arrowPrefab;
        private Transform _transform;
        private ArcherAudio _audio;

        public ArcherAttackState(float attackCooldown, float damage, Transform attackPoint, Vector2 attackZone,
            LayerMask playerMask, EnemyView enemyView, GameObject arrowPrefab, Transform transform, EnemyAttackHelper enemyAttackHelper, ArcherAudio audio)
            : base(attackCooldown, damage, attackPoint, attackZone, playerMask, enemyView, enemyAttackHelper)
        {
            _arrowPrefab = arrowPrefab;
            _transform = transform;
            _audio = audio;
        }

    
        protected override void DealDamage()
        {
            GameObject arrowObject = Object.Instantiate(_arrowPrefab, _attackPoint.position, Quaternion.identity);
            Vector3 arrowScale = _transform.localScale;
            arrowObject.transform.localScale = arrowScale;
            Arrow arrow = arrowObject.GetComponent<Arrow>();
            arrow.Damage = _damage;
            _audio.Shot();

        }
    }
}