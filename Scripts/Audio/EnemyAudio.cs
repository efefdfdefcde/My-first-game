using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] protected AudioClip[]  _damage;
    [SerializeField] protected AudioClip[] _death;

    protected AudioSource _source => GetComponent<AudioSource>();



    public void Damage()
    {
        int number = Random.Range(0, _damage.Length);
        _source.PlayOneShot(_damage[number]);
    }

    public void Death()
    {
        int number = Random.Range(0, _death.Length);
        AudioSource.PlayClipAtPoint(_death[number],transform.position);
    }
}
