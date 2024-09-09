using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss3
{
    public class CircleSpawner : MonoBehaviour
    {
        [SerializeField] private Boss3Controll _boss3Controll;
        [SerializeField] private GameObject _circlePrefab;

        private Animator _animator;
        private AudioSource _source;

        public Transform _player { get; set; }

       
        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _player = FindObjectOfType<Player>().transform;
            _boss3Controll._circleSpawnAction += SpawnAnimation;
            _animator = GetComponent<Animator>();
        }

        private void SpawnAnimation()
        {
            _source.Play();
            _animator.Play("Spawn");
        }

        private void CircleSpawn() //Animation Call
        {
            Instantiate(_circlePrefab,transform.position,Quaternion.identity);
        }

        private void OnDestroy()
        {
            _boss3Controll._circleSpawnAction -= SpawnAnimation;
        }
    }
}