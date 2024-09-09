using Assets.Scripts.Bosses.Boss3;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletCircle : MonoBehaviour
{
    [SerializeField] private Bullet[] _bullets;

    [SerializeField] private float _rotationSpeed;


    private List<Bullet> _spawnedBullets = new List<Bullet>();
    private Transform _player;
    private int _bulletIndex;

    public static Action _changeStateAction;

    private void Start()
    {
        _player = FindObjectOfType<CircleSpawner>()._player;
        Boss3Controll._onDeathAction += OnDeath;
    }

    private void Update()
    {
        Rotation();
        SpawnCheck();
    }

    private void Rotation()
    {
        transform.Rotate(0,0,_rotationSpeed * Time.deltaTime);
    }

    private void SpawnCheck()
    {     
        if (_spawnedBullets.Count == 0 && _bulletIndex != _bullets.Length )
        {
            BulletSpawn(_bullets[_bulletIndex]);
            _bulletIndex++;
        }
        else if (_bulletIndex == _bullets.Length && _spawnedBullets.Count == 0)
        {
            _changeStateAction?.Invoke();
            OnDeath();
        }
    }

    private void BulletSpawn(Bullet bullet)
    {

        bullet.transform.SetParent(null);
        _spawnedBullets.Add(bullet);
        bullet._destroyAction += BulletRemove;
        bullet.Dirrection = (_player.transform.position - transform.position).normalized;


    }

    private void BulletRemove(Bullet bullet)
    {
        bullet._destroyAction -= BulletRemove;  
        _spawnedBullets.Remove(bullet);
    }

    private void OnDeath()
    {
        Boss3Controll._onDeathAction -= OnDeath;
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
       
    }
}
