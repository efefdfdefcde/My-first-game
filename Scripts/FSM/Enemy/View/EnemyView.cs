using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyView : CharacterAnimator
    {

        public void Idle()
        {
            ChangeAnimation("Idle");
        }

        public void Move()
        {
            ChangeAnimation("Move");
        }

        public virtual void Attack()
        {
            ChangeAnimation("Attack");
        }

        public void Damage()
        {
            ChangeAnimation("Damage");
        }
    }
}