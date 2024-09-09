using Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class Stage2 : MonoBehaviour
    {
        [SerializeField] private Transform _safePoint;
        [SerializeField] private ParticleSystem _smoke;
        [SerializeField] private ParticleSystem _safePointSmoke;
        [SerializeField] private float _spawnDelay;

        private Boss1View _view;
        private Boss1Audio _audio => GetComponent<Boss1Audio>();

        public Action _changeStateAction;

        [Serializable]
        class Wave
        {
            public int cout1;
            public int cout2;
            public Enemy _enemyPrefab;
            public Transform _spawnPoint1;
            public Transform _spawnPoint2;
        }

        [SerializeField] private List<Wave> _waves;

        private int _waveIndex;
        private Wave _curentWave => _waves[_waveIndex];

        private List<Enemy> _spawnedEnemyes = new List<Enemy>();

        private void Start()
        {
            _smoke.Play();
            _audio.Smoke();
            _smoke.transform.SetParent(null);
            _safePointSmoke.Play();
            transform.position = _safePoint.position;
            _view = GetComponent<Boss1View>();
            _view.Idle();
            transform.localScale = Vector3.one;
            DeadEnemy._removeAction += ListRemove;
        }

        private void Update()
        {
            SpawnChesk();
        }

        private void SpawnChesk()
        {
            if(_spawnedEnemyes.Count == 0 && _waveIndex !=_waves.Count)
            {
                StartCoroutine(Spawn());
               
            }
            else if (_spawnedEnemyes.Count == 0 && _waveIndex == _waves.Count)
            {
                _changeStateAction?.Invoke();
            }
        }

        private IEnumerator Spawn()
        {
           
            if (_curentWave.cout1 != 0)
            {

                for (int i = 0; i < _curentWave.cout1; i++)
                {
                    var enemy = Instantiate(_curentWave._enemyPrefab, _curentWave._spawnPoint1.position, Quaternion.identity);
                    enemy.transform.localScale = new Vector3(-1, 1);
                    _spawnedEnemyes.Add(enemy);
                    yield return new WaitForSeconds(_spawnDelay);
                }
                
            }

            if (_curentWave.cout2 != 0)
            {

                for (int i = 0; i < _curentWave.cout2; i++)
                {
                    var enemy = Instantiate(_curentWave._enemyPrefab, _curentWave._spawnPoint2.position, Quaternion.identity);
                    enemy.transform.localScale = new Vector3(1, 1);
                    _spawnedEnemyes.Add(enemy);
                    yield return new WaitForSeconds(_spawnDelay);
                }
               
            }
            _waveIndex++;
        }


        private void ListRemove(Enemy enemy)
        {
           
            _spawnedEnemyes.Remove(enemy);
           
        }


    }
}