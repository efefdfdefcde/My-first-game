using System.Collections;
using UnityEngine;

namespace Assets.FSM
{
    public class JumpState : State
    {
        private PlayerView PlayerView;
        private float _jumpForce;
        private Rigidbody2D Rigidbody2D;
        private GroudChecker GroudChecker;
        private PlayerAudio PlayerAudio;
       

        public JumpState(PlayerView playerView, float jumpForce, Rigidbody2D rigidbody2D, GroudChecker groudChecker, PlayerAudio playerAudio)
        {
            PlayerView = playerView;
            _jumpForce = jumpForce;
            Rigidbody2D = rigidbody2D;
            GroudChecker = groudChecker;
            ControlKeys._jumpAction += Jump;
            PlayerAudio = playerAudio;
        }


        public override void Update()
        {

            if (GroudChecker.Check())PlayerView.Idle();
            else PlayerView.Jump(); 
        }

        private void Jump()
        {
            if (GroudChecker.Check())
            {
                Rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                PlayerAudio.Jump();
            }

        }

        public void Description()
        {
            ControlKeys._jumpAction -= Jump;
        }
    }
}