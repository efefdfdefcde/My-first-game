using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2.Stage2
{
    public class RainDrop : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifetime;
        [SerializeField] private AudioClip _electricity;



        private void OnEnable()
        {
            StartCoroutine(Timer());
        }

        private void Update()
        {
            Fall();

        }

        private void Fall()
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<Player>().TakeDamage(_damage);
                AudioSource.PlayClipAtPoint(_electricity, transform.position);
                gameObject.SetActive(false);    
            }
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(_lifetime);
            gameObject.SetActive(false);
        }

    }
}