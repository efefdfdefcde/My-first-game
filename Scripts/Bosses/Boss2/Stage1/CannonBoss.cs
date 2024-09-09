using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBoss : MonoBehaviour
{
    [SerializeField] private float _reloadTime;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private GameObject _canonbalPrefab;
    [SerializeField] private ParticleSystem _shotSmoke;
    [SerializeField] private Vector2 _checkZone;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootPower;
    [SerializeField] private AudioClip _shot;

    private float _currentTime;
    private AudioSource _source => GetComponent<AudioSource>();

    public Action<float,float> _reloadAction;

    private void Update()
    {
        Shot();
    }

    private void Shot()
    {
        _currentTime += Time.deltaTime;
        _reloadAction?.Invoke(_reloadTime, _currentTime);
        if (Input.GetKeyDown("f") && _currentTime >= _reloadTime)
        {
            var player = Physics2D.OverlapBox(transform.position, _checkZone,0,_playerMask);
            if (player != null)
            {
                _source.PlayOneShot(_shot);
                var cannonbal = Instantiate(_canonbalPrefab, _shootPoint.position, Quaternion.identity);
                Rigidbody2D rb = cannonbal.GetComponent<Rigidbody2D>();
                rb.AddForce(_direction * _shootPower,ForceMode2D.Impulse);
                _currentTime = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _checkZone);
    }
}
