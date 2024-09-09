using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace Assets.Scripts {
    public class Arrow : MonoBehaviour
    {
        public float Damage {  get; set; }
        [SerializeField] protected float _speed;
        private Rigidbody2D _arrowRigidbody;

        protected virtual void Start()
        {
            _arrowRigidbody = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Fly();
        }

        protected virtual void Fly()
        {
            Vector2 direction = new Vector2(-transform.localScale.x, 0);
            _arrowRigidbody.AddForce(direction * _speed * Time.deltaTime, ForceMode2D.Impulse);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                try { collision.GetComponent<Player>().TakeDamage(Damage); }
                catch { NullReferenceException ex; }
               
                OnHit();
            }

        }

        protected virtual void OnHit()
        {
            Destroy(gameObject);
        }

    }
}