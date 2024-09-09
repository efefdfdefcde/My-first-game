using System;
using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.Steals
{
    public class StealsZone : MonoBehaviour
    {
        public static Action<bool> _inHideAction;
        public static Action _outHideAction;
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {

                _inHideAction?.Invoke(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _inHideAction?.Invoke(false);
                _outHideAction.Invoke();
            }
        }
    }
}