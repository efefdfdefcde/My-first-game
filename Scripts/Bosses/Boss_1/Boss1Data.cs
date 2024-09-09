using Assets.Scripts.Bosses;
using System.Collections;
using UnityEngine;

public class Boss1Data : Data
{
    [SerializeField] private GameObject _windPrefab;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private Vector2 _attackZone;
    [SerializeField] private Vector2 _attackZoneSt3;
    [SerializeField] private Vector2 _detectionArea;
    [SerializeField] private float _detectionRange;
    private Boss1View _view;

    protected override void Init()
    {
        base.Init();
        _view = (Boss1View)CharacterAnimator;
    }

    public Boss1View GetView() 
    {
        return _view;
    }

    public float GetCooldown() 
    {
        return _attackCooldown;
    }

    public LayerMask GetPlayerMask()
    {
        return _playerMask;
    }

    public Vector2 GetAttackZone()
    {
        return _attackZone;
    }

    public GameObject GetWindPrefab()
    {
        return _windPrefab; 
    }

    public Vector2 GetDetectionArea()
    {
        return _detectionArea;
    }

    public float GetDetectionRange()
    {
        return _detectionRange;
    }

    public Vector2 GetAttackSt3()
    {
        return _attackZoneSt3;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_attackPoint.position, _attackZone);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position,_attackZoneSt3 );
        Gizmos.color = Color.blue;
        Vector2 detectionArea = new Vector2(_detectionRange,_detectionArea.y);
        Gizmos.DrawWireCube(_attackPoint.position, detectionArea);
    }

}
