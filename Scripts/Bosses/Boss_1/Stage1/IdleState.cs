using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class IdleState : State
    {
        private Boss1View _bossView;

        public IdleState(Boss1View boss1View)
        {
            _bossView = boss1View;
        }

        public override void Enter()
        {
            _bossView.Idle();
        }

    }
}