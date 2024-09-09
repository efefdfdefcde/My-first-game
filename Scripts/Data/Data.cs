using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

 public abstract class Data : MonoBehaviour
 {
    [SerializeField] private float _speed;
    [SerializeField] protected Transform _attackPoint;

    public Rigidbody2D Rigidbody2D { get; private set; }
    public Collider2D Collider2D { get; private set; }
   
    protected CharacterAnimator CharacterAnimator;
    

    //Characteristic
    [SerializeField] protected Characteristics _characteristics;
    public float MaxHealth { get; private set; }
    public int Damage { get; private set; }

    private void Awake()
    {
        Init();
        ChrtInit();
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public Transform GetAttackPoint()
    {
        return _attackPoint;
    }

    protected virtual void Init()
    {
        CharacterAnimator = GetComponent<CharacterAnimator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<Collider2D>();
       
    }

    protected virtual void ChrtInit()
    {
        MaxHealth = _characteristics._maxHealth;
        Damage = _characteristics._damage;
    }
 }
