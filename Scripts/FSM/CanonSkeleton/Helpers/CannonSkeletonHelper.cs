using Assets.NewScripts.FSM.Enemy.Helpers;
using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.FSM.CanonSkeleton.Helpers
{
    public class CannonSkeletonHelper : EnemyAttackHelper
    {
        [SerializeField] private ParticleSystem _shotEffect;

        private void OnShot()
        {
            _shotEffect.Play();
        }
        
    }
}