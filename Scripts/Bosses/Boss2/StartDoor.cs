using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2
{
    public class StartDoor : MonoBehaviour
    {
        [SerializeField] private Collider2D _startDoor;

        public Action _startBatttleAction;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _startBatttleAction?.Invoke();
                _startDoor.enabled = true;
            }
        }
    }
}