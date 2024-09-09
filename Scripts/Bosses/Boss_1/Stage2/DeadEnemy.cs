using Characters;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class DeadEnemy : MonoBehaviour
    {
        public static Action<Enemy> _removeAction;

        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
           
        }

       
        private void OnDestroy()
        {
            _removeAction?.Invoke(_enemy);
        }
          
        
    }
}