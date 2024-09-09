using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] protected GameObject _arrowPrefab;
    [SerializeField] protected float _damage;
    [SerializeField] protected AudioClip _shot;

    private AudioSource _source => GetComponent<AudioSource>();

    public virtual void Shoot()
    {
        GameObject arrowGO = Instantiate(_arrowPrefab, transform.position, Quaternion.identity);
        Vector3 arrowScale = gameObject.transform.localScale;
        arrowGO.transform.localScale = arrowScale;
        Arrow arrow = arrowGO.GetComponent<Arrow>();
        arrow.Damage = _damage;
        _source.PlayOneShot(_shot);
    }
}
