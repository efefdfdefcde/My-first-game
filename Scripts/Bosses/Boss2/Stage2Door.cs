using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2
{
    public class Stage2Door : MonoBehaviour
    {
        [SerializeField] private Collider2D _door;

        public Action _stage2DoorAction;


        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _door.enabled = true;
                _stage2DoorAction?.Invoke();
            }
        }
    }
}