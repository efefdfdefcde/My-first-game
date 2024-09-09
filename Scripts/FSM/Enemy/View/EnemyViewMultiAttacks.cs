using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Enemy
{
    public class EnemyViewMultiAttacks : EnemyView
    {
        [SerializeField] private string[] attack_animations;

        public override void Attack()
        {
            int attack_number = Random.Range(0, attack_animations.Length);
            string attack_animation = attack_animations[attack_number];
            ChangeAnimation(attack_animation);
        }
    }
}