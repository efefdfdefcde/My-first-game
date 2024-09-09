using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2.Stage1
{
    public class Spirit : Arrow
    {
        public Vector3 Direction { set; private get; }

        protected override void Start()
        {
            
        }

        protected override void Fly()
        {

            transform.position += Direction * _speed * Time.deltaTime;

        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                try { collision.GetComponent<Player>().TakeDamage(Damage); }
                catch { NullReferenceException ex; }

                OnHit();
            }
            if (collision.CompareTag("Tank"))
            {
                try { collision.GetComponent<Tank>().TakeDamage(Damage); }
                catch { NullReferenceException ex; }

                OnHit();
            }
        }
    }
}