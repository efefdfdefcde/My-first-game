using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data.Necromancer
{
    public class NecromancerData : EnemyData
    {

        [SerializeField] private GameObject _skeletonPrefab;
        [SerializeField] private ParticleSystem _spawnEffect;

        public GameObject GetPrefab()
        { 
            return _skeletonPrefab;
        }

        public ParticleSystem GetSpawnEffect()
        {
            return _spawnEffect;
        }
    }
}