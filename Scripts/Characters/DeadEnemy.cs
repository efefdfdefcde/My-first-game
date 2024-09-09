using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Enemy
{
    public class DeadEnemy : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private ParticleSystem _blood;
        [SerializeField] private GameObject _coin;
        [SerializeField] private int _coinQuantity;
        [SerializeField] private float _coinSpawnInterval;
        [SerializeField] private AudioClip _coinSpawn;

        private AudioSource _source => GetComponent<AudioSource>();

        private void Start()
        {
            _blood.Play();
        }

        private IEnumerator OnDeath()
        {
            for (int i = 0; i < _coinQuantity; i++)
            {
                Instantiate(_coin, _spawnPoint.position, Quaternion.identity);
                _source.PlayOneShot(_coinSpawn);
                yield return new WaitForSeconds(_coinSpawnInterval);
            }
            
        }
     
    }
}