using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.Environment
{
    public class CannonTrap : ArrowTrap
    {

        [SerializeField] private ParticleSystem _shootEffect;

        public override void Shoot()
        {
            _shootEffect.Play();
            base.Shoot();
        }
    }
}