using Assets.NewScripts.FSM.Enemy.Helpers;
using Assets.NewScripts.FSM.Enemy.States;
using System;
using System.Collections;
using UnityEngine;


namespace Assets.NewScripts.FSM.Enemy
{
    public class EnemyControll : MonoBehaviour
    {
        [SerializeField] private Characters.Enemy _enemy;
        [SerializeField] private bool _canPatrol;
      

        protected EnemyData EnemyData;
        protected StateMashine StateMashine = new StateMashine();
        private EnemyIdleState idleState;
        protected EnemyAttackState attackState;
        private EnemyPatrollingState patrolState;
        private EnemyPersuitState persuitState;
        protected EnemyAttackHelper attackHelper;
        private EnemyDamageState damageState;

        private bool _onDamage;

        public  Action<Collider2D> persuitInfoAction;
        public Action _stealsKillAction;
       
        private void Start()
        {

            attackHelper = GetComponent<EnemyAttackHelper>();
            EnemyData = GetComponent<EnemyData>();
            Init();
            if (_canPatrol )StateMashine.Initialize(patrolState);
            else StateMashine.Initialize(idleState);
            _enemy._onDamageAction += OnDamage;
           
        }

     
        private void Update()
        {
            Controll();
            StateMashine.CurrentState.Update();
           
        }

        private void Controll()
        {
            Collider2D attackPlayer = Physics2D.OverlapBox(EnemyData.GetAttackPoint().position, EnemyData.GetAttackZone(), 0, EnemyData.GetPlayerMask());
            Vector2 direction = transform.localScale.x > 0 ? Vector2.left : Vector2.right;
            RaycastHit2D findPlayer = Physics2D.BoxCast(EnemyData.GetAttackPoint().position, EnemyData.GetDetectionArea(), 0, direction, EnemyData.GetDetectionRange(), EnemyData.GetPlayerMask());
           

            if (_onDamage)
            {
                if(!attackPlayer && !findPlayer)_stealsKillAction.Invoke();
                StateMashine.ChangeState(damageState);
                return;
            }

            if (attackPlayer && !findPlayer)
            {
                Swap();
            }

            if(findPlayer && !attackPlayer)
            {
                persuitInfoAction.Invoke(findPlayer.collider);
                StateMashine.ChangeState(persuitState);
            }

            if (attackPlayer)
            {
                Attack();
            }

            if (!attackPlayer && !findPlayer)
            {
                if (_canPatrol)
                {
                    StateMashine.ChangeState(patrolState);
                }
                else StateMashine.ChangeState(idleState);
            }   
        }

        protected virtual void Attack()
        {
            StateMashine.ChangeState(attackState);
        }

        private void Swap()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        protected virtual void Init()
        {
            idleState = new EnemyIdleState(EnemyData.EnemyView);
            attackState = new EnemyAttackState(EnemyData.GetAttackCooldown(),EnemyData.Damage,EnemyData.GetAttackPoint()
                ,EnemyData.GetAttackZone(),EnemyData.GetPlayerMask(),EnemyData.EnemyView,attackHelper);
            patrolState = new EnemyPatrollingState(EnemyData.EnemyView, transform, EnemyData.GetPointA(), EnemyData.GetPoinB(), EnemyData.GetSpeed());
            persuitState = new EnemyPersuitState(EnemyData.EnemyView, transform, EnemyData.GetSpeed(), this);
            damageState = new EnemyDamageState(EnemyData.EnemyView);
        }

        private void OnDamage(bool status)
        {
            _onDamage = status;
        }

        protected void DamageEnd()//AnimationCall
        {
            _onDamage = false;
        }

        protected virtual void OnDestroy()
        {
            persuitState.OnDestroy();
            attackState.OnDestroy();
        }
    }
}