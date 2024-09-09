using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class BossAudio : MonoBehaviour
    {
        [SerializeField] protected AudioClip _damage, _death;

        protected AudioSource _source => GetComponent<AudioSource>(); 
        
        public void Damage()
        {
            _source.PlayOneShot(_damage);
        }

        public void Death()
        {
            AudioSource.PlayClipAtPoint(_death, transform.position);
        }
       
    }
}