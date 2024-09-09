using System.Collections;
using UnityEngine;



    public class PlayerView : CharacterAnimator
    {
       

        [SerializeField] private string[] attack_animations;
        public void Idle()
        {
            ChangeAnimation("Player_Idle");
        }

        public void Move(float horizontal, bool onGround)
        {
            if (horizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
            if (horizontal > 0) transform.localScale = new Vector3(1, 1, 1);
            if (horizontal == 0 && onGround) { Idle(); return; }
            else if (horizontal !=0 && !onGround) { Jump(); return; }
            ChangeAnimation("Player_Move");
            
        }

        public void Jump()
        {
            ChangeAnimation("Player_Jump");
         
        }

      

        public void Attack()
        {
            int attack_number = Random.Range(0, attack_animations.Length);
            string attack_animation = attack_animations[attack_number];
            ChangeAnimation(attack_animation);
           
           
        }

        public void Block()
        {
            ChangeAnimation("Player_Block");
        }


     

        
    }
