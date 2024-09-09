using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Chest : MonoBehaviour
    {
        private AudioSource _source => GetComponent<AudioSource>();
        private Animator animator;
        private bool _full = true;

        public delegate void Chest_Open(int value);
        public event Chest_Open Chest_Open_Event;
        [SerializeField] protected int value;
        [SerializeField] protected AudioClip _open;
        

        private void Start()
        {
            animator = GetComponent<Animator>();   
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.CompareTag("Player"))
            {
               
                animator.Play("Chest_Open");
                if (_full)
                {
                    _source.PlayOneShot(_open);
                    _full = false;
                    Chest_Open_Event?.Invoke(value);
                }
            }
        
        }



        private void OnTriggerExit2D(Collider2D collision)
        {
           
            if (collision.CompareTag("Player"))
            {
                animator.Play("Chest_Close");
            } 
        }
      
        
    }
}