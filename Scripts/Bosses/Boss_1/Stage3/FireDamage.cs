using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class FireDamage : MonoBehaviour
    {
        [SerializeField] private float _damageTime;
        [SerializeField] private float _damage;
        [SerializeField] private Vector2 _fireZone;
        [SerializeField] private LayerMask _playerMask;

        private void Start()
        {
            InvokeRepeating(nameof(Fire), _damageTime, _damageTime);

        }

        private void Fire()
        {
            //yield return new WaitForSeconds(_damageTime);
            var playerCol = Physics2D.OverlapBox(transform.position,_fireZone,0,_playerMask);
            if (playerCol != null)
            {
                Player player = playerCol.GetComponent<Player>();
                player.TakeDamage(_damage);
            }
           
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, _fireZone);
        }
    }
}