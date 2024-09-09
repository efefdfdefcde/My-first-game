using System;
using System.Collections;
using UnityEngine;

namespace Assets.FSM
{
    public class BlockState : State
    {
        private PlayerView PlayerView;

        public static Action _blockCheckAction;
        public static Action<bool> _blockStatusAction;

        public BlockState(PlayerView playerView)
        {
            PlayerView = playerView;
            StaminaPool._blockCall += Block;
        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            _blockStatusAction?.Invoke(false);
        }

        public override void Update()
        {
            if (Input.GetButton("Fire2"))
            {
                BlockCheck();
            }
            else { PlayerView.Idle(); _blockStatusAction?.Invoke(false); }
        }

        private void BlockCheck()
        {
            _blockCheckAction.Invoke();
        }

        private void Block(bool answer)
        {
            if (answer)
            {
                PlayerView.Block();
                _blockStatusAction?.Invoke(true);
            }
            else { PlayerView.Idle(); _blockStatusAction?.Invoke(false);}
        }
           

    }
}