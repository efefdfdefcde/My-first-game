using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class Boss1View : CharacterAnimator
    {

        public void Idle()
        {
            ChangeAnimation("Idle");
        }

        public  void Attack()
        {
            ChangeAnimation("Attack");
        }

        public void HeavyAttack()
        {
            ChangeAnimation("HeavyAttack");
        }

        public void RangeAttack()
        {
            ChangeAnimation("RangeAttack");
        }

        public void Move()
        {
            ChangeAnimation("Move");
        }

        public void HightAttack()
        {
            ChangeAnimation("HightAttack");
        }

    }
}