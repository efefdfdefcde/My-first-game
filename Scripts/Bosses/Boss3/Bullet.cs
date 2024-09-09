using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask _bossMask;
    [SerializeField] private float _damage;
    [SerializeField] private float _radius;


    public Vector3 Dirrection { set; private get; }

    private Animator _animator;
    private AudioSource _source;
    private LayerMask _currentMask;

    public Action<Bullet> _destroyAction;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _currentMask = _playerMask;
    }



    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        if (Dirrection != null)
        {
            transform.position += Dirrection * _speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit();

    }

    private void OnHit()
    {
        Dirrection = Vector3.zero;
        _animator.Play("BulletDamage");
        var objs = Physics2D.OverlapCircleAll(transform.position, _radius,_currentMask);
        foreach(var obj in objs)
        {
            try
            {
                obj.TryGetComponent(out Character character);
                character.TakeDamage(_damage);
            }
            catch { NullReferenceException nullReferenceException; }
        }
    }

    private void Destroy() //AnimationCall
    {
        _destroyAction?.Invoke(this);
        Destroy(gameObject);
    }

    public void ChangeDirrection()
    {
        _source.Play();
        Dirrection = (FindObjectOfType<Boss>().transform.position - transform.position).normalized;
        gameObject.layer = 0;
        _currentMask = _bossMask;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
