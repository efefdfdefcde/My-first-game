using UnityEngine;

namespace Assets.Scripts.Bosses.Boss3
{
    public class Thunderbolt : MonoBehaviour
    {

        [SerializeField] private ParticleSystem _thunderEffect;
        [SerializeField] private Vector2 _damageZone;
        [SerializeField] private float _damage;
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private AudioClip _thunder;

        private AudioSource _source;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _source = GetComponent<AudioSource>();
        }

        public void ThunderEffect()
        {
            _thunderEffect.Play();
        }

        public void Thunder()
        {
            _thunderEffect.Stop();
            _animator.Play("Thunder");
            _source.PlayOneShot(_thunder);
            var player = Physics2D.OverlapBox(transform.position, _damageZone,0,_playerMask);
            if (player != null )
            {
                player.GetComponent<Player>().TakeDamage(_damage);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, _damageZone);
        }
    }
}