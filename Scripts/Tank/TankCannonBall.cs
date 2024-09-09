using Characters;
using UnityEngine;

public class TankCannonBall : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private float _damage;
    [SerializeField] private float _damageRadius;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private AudioClip _explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _explosionEffect.transform.SetParent(null);
        _explosionEffect.Play();
        Collider2D[] enemyes = Physics2D.OverlapCircleAll(transform.position, _damageRadius,_enemyMask);
        if (enemyes.Length > 0)
        {
            foreach (var enemy in enemyes)
            {
                enemy.GetComponent<Character>().TakeDamage(_damage);
            }
        }
        AudioSource.PlayClipAtPoint(_explosion, transform.position);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _damageRadius);
    }
}
