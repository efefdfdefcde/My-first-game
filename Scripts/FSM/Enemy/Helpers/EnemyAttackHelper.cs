using System;
using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.FSM.Enemy.Helpers
{
    public class EnemyAttackHelper : MonoBehaviour
    {

        public Action _damageAction;

        private void DamageCall()
        {
            _damageAction?.Invoke();
        }
    }
}