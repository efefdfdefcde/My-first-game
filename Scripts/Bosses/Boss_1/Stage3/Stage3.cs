using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class Stage3 : MonoBehaviour
    {
        [SerializeField] private Transform _fireSpawnPosition;
        [SerializeField] private FireDamage _fireDamage;
        [SerializeField] private ParticleSystem _attackEffect;
        [SerializeField] private float _cooldown;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _waitAttack1;
        [SerializeField] private float _waitAttack2;
        [SerializeField] private float _damage;
        

        

        private Transform _attackTarget;
        private float _attackTime;
        private Boss1View _view;
        private Boss1Data _data;
        private Vector2 _attackZone;
        private LayerMask _playerMask;
        private ParticleSystem attackEffect;
        private Boss1Audio _audio => GetComponent<Boss1Audio>();

        private void Start()
        {
            _view = GetComponent<Boss1View>();
            _attackTarget = FindObjectOfType<Player>().transform; 
            _data = GetComponent<Boss1Data>();
            _attackZone = _data.GetAttackSt3();
            _playerMask = _data.GetPlayerMask();
        }

        private void Update()
        {
            if (_attackTime <= Time.time)
            {
                _attackTime = Time.time + _cooldown;
                StartCoroutine(AttackPreparing());
            }
        }

        private IEnumerator AttackPreparing()
        {
            var fireDamage = Instantiate(_fireDamage,_fireSpawnPosition.position,_fireDamage.transform.rotation);
            _audio.Gas();
            yield return new WaitForSeconds(_waitAttack1);
            attackEffect = Instantiate(_attackEffect, _attackTarget.position, Quaternion.identity);
            yield return new WaitForSeconds(_waitAttack2);
            _view.Move();
            _audio.Attack();
           
            Destroy(fireDamage.gameObject);

        }

        private void Attack1()
        {
            Vector2 attackPosition = new Vector2(attackEffect.transform.position.x, transform.position.y);
            Destroy(attackEffect);
            transform.position = attackPosition;
            _view.HightAttack();
            DealDamage();
        }



        private void DealDamage()
        {
            Collider2D playerCol = Physics2D.OverlapBox(transform.position, _attackZone, 0, _playerMask);
            if (playerCol != null)
            {
                Player player = playerCol.GetComponent<Player>();
                player.TakeDamage(_damage);
            }
            
        }

    }
}