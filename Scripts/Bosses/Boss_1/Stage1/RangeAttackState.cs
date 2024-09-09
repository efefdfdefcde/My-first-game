using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class RangeAttackState : State
    {
        private GameObject WindPrefab;
        private Transform _transform;
        private Boss1View Boss1View;
        private float _damage;
        private float _nextAttackTime;
        private float _attackCooldown;
        private Transform _attackPoint;
        private Boss1Audio _audio;


        public RangeAttackState(GameObject windPrefab, Transform transform, Boss1View boss1View, float damage, float attackCooldown, Transform attackPoint, Boss1Audio audio)
        {
            WindPrefab = windPrefab;
            _transform = transform;
            Boss1View = boss1View;
            _damage = damage;
            _attackCooldown = attackCooldown;
            _attackPoint = attackPoint;
            _audio = audio;
            Boss1AttackHelper._rangeAttackAction += WindSpawn;
        }

        public override void Enter()
        {
            Boss1View.Idle();
        }

        public override void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + _attackCooldown;
                Boss1View.RangeAttack();
            }

        }

        private void WindSpawn()
        {
            GameObject windObject = Object.Instantiate(WindPrefab, _attackPoint.position, Quaternion.identity);
            _audio.Wind();
            Vector3 windScale = _transform.localScale;
            windObject.transform.localScale = windScale;
            Wind wind = windObject.GetComponent<Wind>();
            wind.Damage = _damage;
        }

        public void OnDisable()
        {
            Boss1AttackHelper._rangeAttackAction -= WindSpawn;
        }


    }
}