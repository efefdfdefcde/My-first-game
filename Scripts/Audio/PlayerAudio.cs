using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _walk, _jump, _block, _missAttack, _damage, _heal, _death, _load;

    private AudioSource _source => GetComponent<AudioSource>();

    public void Walk()
    {

        _source.PlayOneShot(_walk);
    }

    public void Jump()
    {
        _source.PlayOneShot(_jump);
    }

    public void Block()
    {
        _source.PlayOneShot(_block);
    }

    public void MissAttack()
    {
        _source.PlayOneShot(_missAttack);
    }

    public void Damage()
    {
        _source.PlayOneShot(_damage);
    }

    public void Heal()
    {
        _source.PlayOneShot(_heal);
    }

    public void Death()
    {
        AudioSource.PlayClipAtPoint(_death,transform.position);
    }

    public void Load()
    {
        _source.PlayOneShot(_load);
    }

}
