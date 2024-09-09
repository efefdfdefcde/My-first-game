using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class Boss1AttackHelper : MonoBehaviour
    {

        public static Action<bool> _damageType;
        public static Action _rangeAttackAction;

        private void Damage()
        {
            _damageType?.Invoke(false);
        }

        private void HeavyDamage()
        {
            _damageType?.Invoke(true);
        }

        private void RangeAttack1()
        {
            _rangeAttackAction?.Invoke();
        }
    }
}