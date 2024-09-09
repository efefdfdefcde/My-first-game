using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Finish_Level : MonoBehaviour
    {
        public delegate void Finish_Level_Delegate();
        public static event Finish_Level_Delegate finish_level_event;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                finish_level_event.Invoke();
            
            }
        }
    }
}