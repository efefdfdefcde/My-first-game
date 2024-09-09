using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Arrow
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioClip _explosion;

    protected override void OnHit()
    {
        _explosionEffect.Play();
        _explosionEffect.transform.SetParent(null);
        AudioSource.PlayClipAtPoint(_explosion,transform.position);
        Destroy(gameObject);
    }
}
