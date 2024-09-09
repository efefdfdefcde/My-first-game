using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _cannonballPrefab;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private float _offcet;
    [SerializeField] private float _minOffcet;
    [SerializeField] private float _maxOffcet;
    [SerializeField] private float _reload;
    [SerializeField] private float _shootPower;
    [SerializeField] private AudioClip _shot;

    private float _currentTime;
    private AudioSource _source;

    public Action<float, float> _reloadAction;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CannonRotation();
        Shoot();
    }

    private void CannonRotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        rotation = Mathf.Clamp(rotation, _minOffcet, _maxOffcet);
        transform.rotation = Quaternion.Euler(0,0,-rotation + _offcet);
      

    }

    private void Shoot()
    {
        _currentTime += Time.deltaTime;
        _reloadAction?.Invoke(_reload, _currentTime);
        if (Input.GetButtonDown("Fire1") &&  _currentTime >= _reload)
        {
            _currentTime = 0;
            _source.PlayOneShot(_shot);
            GameObject canonnbalGO = Instantiate(_cannonballPrefab,_shootPoint.position,Quaternion.identity);
            Rigidbody2D rigidbody2D = canonnbalGO.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce((_shootPoint.position - transform.position).normalized * _shootPower);
            _shootEffect.Play();
        }

    }


}
