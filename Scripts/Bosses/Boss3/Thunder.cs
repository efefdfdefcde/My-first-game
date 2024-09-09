using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss3
{
    public class Thunder : MonoBehaviour
    {
       

        public Action _changeStateAction;

        [SerializeField] private Boss3Controll _bossControll;

        [SerializeField] private Thunderbolt[] _thunderbolts;

        [Serializable]
        class ThunderWave
        {
            public Transform[] _positions;
            public float[] _delay;
        }

        [SerializeField] private ThunderWave[] _wawes;

        private void Start()
        {
            _bossControll._thunderSpawnAction += StartSpwawn;
        }

        private void StartSpwawn()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            for(int i = 0; i < _wawes.Length; i++)
            {
                for (int j = 0; j < _wawes[i]._positions.Length; j++)
                {
                    for(int k = 0; k <= _thunderbolts.Length; k++)
                    {
                        if (_thunderbolts[k].transform.position == _wawes[i]._positions[j].position)
                        {
                            _thunderbolts[k].ThunderEffect();
                            break;
                        }
                    }
                    yield return new WaitForSeconds(_wawes[i]._delay[j]);
                }

                for(int z = 0; z < _wawes[i]._positions.Length; z++)
                {
                    for (int k = 0; k <= _thunderbolts.Length; k++)
                    {
                        if (_thunderbolts[k].transform.position == _wawes[i]._positions[z].position)
                        {
                            _thunderbolts[k].Thunder();
                            break;
                        }
                    }
                    yield return new WaitForSeconds(_wawes[i]._delay[z]);
                }
            }
            _changeStateAction?.Invoke();
        }

        private void OnDestroy()
        {
            _bossControll._thunderSpawnAction -= StartSpwawn;
        }
    }
}