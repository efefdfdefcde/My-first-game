using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
     
    [SerializeField] protected GameObject _deadCharacter;
   
    
    protected float _maxHealth;

    protected float _currentHealth { get; set; }
    protected bool _isDead => _currentHealth <= 0;

   public virtual void TakeDamage(float damage)
   { 
        _currentHealth -= damage;
        OnDamage();
        if (_isDead)
        {
            OnDeath();
           
        }
   }


    protected virtual void OnDeath()
    {
        GameObject dead = Instantiate(_deadCharacter, transform.position, Quaternion.identity);
        Vector3 characterScale = gameObject.transform.localScale;
        dead.transform.localScale = characterScale;
        Destroy(gameObject);
    }

    protected virtual void OnDamage()
    {


    }


}
