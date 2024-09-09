using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.Save_System
{
    public class SavePoint2 : SavePoint
    {
        private Animator _animator;

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !_isSave)
            {

                _animator = GetComponent<Animator>();
                _animator.Play("SavePoint2");
                Save();
                _source.Play();
            }
        }
    }
}