using Assets.NewScripts.FSM.Archer;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class Stage1 : MonoBehaviour
    {
        private StateMashine StateMashine = new();
        private MeleeState meleeState;
        private RangeAttackState rangeAttackState;
        private IdleState idleState;
        private Boss1Data boss1Data;
        private Boss1Audio _audio => GetComponent<Boss1Audio>(); 

        private void Start()
        {
            boss1Data = GetComponent<Boss1Data>();
            Init();
            StateMashine.Initialize(idleState);
        }

        private void Update()
        {
            Control();
            StateMashine.CurrentState.Update();
        }


        private void Control()
        {
            Collider2D attackPlayer = Physics2D.OverlapBox(boss1Data.GetAttackPoint().position, boss1Data.GetAttackZone(), 0, boss1Data.GetPlayerMask());
            Vector2 direction = transform.localScale.x > 0 ? Vector2.left : Vector2.right;
            RaycastHit2D findPlayer = Physics2D.BoxCast(boss1Data.GetAttackPoint().position, boss1Data.GetDetectionArea(), 0, direction, boss1Data.GetDetectionRange(), boss1Data.GetPlayerMask());

            if(attackPlayer && !findPlayer)
            {
                Swap();
            }

            if(findPlayer && attackPlayer)
            {
                StateMashine.ChangeState(meleeState);
            }

            if(findPlayer && !attackPlayer)
            {
                StateMashine.ChangeState(rangeAttackState);
            }
        }

        private void Swap()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        private void Init()
        {
            idleState = new(boss1Data.GetView());
            meleeState = new(boss1Data.Damage, boss1Data.GetCooldown(), boss1Data.GetAttackPoint(), boss1Data.GetAttackZone(), boss1Data.GetPlayerMask(), boss1Data.GetView());
            rangeAttackState = new(boss1Data.GetWindPrefab(), transform, boss1Data.GetView(), boss1Data.Damage, boss1Data.GetCooldown(), boss1Data.GetAttackPoint(), _audio);
        }

        private void OnDisable()
        {
            meleeState.OnDisable();
            rangeAttackState.OnDisable();   
        }
    }
}