using Assets.NewScripts.FSM.Enemy;
using System;
using System.Collections;
using UnityEngine;

namespace Characters
{
    public class Enemy : Character
    {

        [SerializeField] protected ParticleSystem _blood;
        protected EnemyControll EnemyControll;

        private EnemyAudio _audio => GetComponent<EnemyAudio>();

        public Action<bool> _onDamageAction;
        public Action<float, float> _UIUpdateAction;

        protected virtual void Start()
        {
            EnemyControll = GetComponent<EnemyControll>();
            EnemyControll._stealsKillAction += StealsKill;
            _maxHealth = GetComponent<EnemyData>().MaxHealth;
            _currentHealth = _maxHealth;
        }

        protected override void OnDamage()
        {
            _blood.Play();
            _audio.Damage();
            _UIUpdateAction?.Invoke(_maxHealth, _currentHealth);
            _onDamageAction?.Invoke(true);
        }

        private void StealsKill()
        {
           
            OnDeath();
            Destroy(gameObject);
        }

        protected override void OnDeath()
        {
            base.OnDeath();
            _audio.Death();
        }

    }

}
