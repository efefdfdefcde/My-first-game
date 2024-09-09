using Assets.Scripts.Bosses.Boss2.Stage2;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss_1.Stage2
{
    public class Rain : MonoBehaviour
    {
        [SerializeField] private GameObject[] _rainDrops;

        [Serializable]
        class RainPoint
        {
            public float _cooldown;
            public float _curentTime;
            public Transform _position;
        }

        [SerializeField] RainPoint[] _points;

        private void Start()
        {
            for(int i = 0; i < _points.Length; i++)
            {
                _points[i]._curentTime = Time.time + _points[i]._cooldown;
            }
        }

        private void Update()
        {
            DropCheck();
        }

        private void DropCheck()
        {
            for(int i = 0; i < _points.Length; i++)
            {
                if(Time.time >= _points[i]._curentTime)
                {
                    _points[i]._curentTime = Time.time + _points[i]._cooldown;
                    DropSpawn(_points[i]._position);
                }
            }
        }

        private void DropSpawn(Transform transform)
        {
            for(int i = 0;i < _rainDrops.Length;i++)
            {
                if (!_rainDrops[i].activeSelf)
                {
                    _rainDrops[i].transform.position = transform.position;
                    _rainDrops[i].SetActive(true);
                    break;
                }
            }
        }
    }
}