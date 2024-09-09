using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss_1
{
    public class Boss1Rotator : Rotator
    {
        public Action _batleBeginAction;

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _batleBeginAction?.Invoke();
                Rotate();
            }
        }
    }
}