using Assets.Scripts;
using UnityEngine;



public class EnemyData : Data
{
    [SerializeField] protected LayerMask _playerMask;
    [SerializeField] protected Vector2 _detectionArea;
    [SerializeField] protected Transform _pointA;
    [SerializeField] protected Transform _pointB;
    [SerializeField] protected Vector2 _attackZone;
    [SerializeField] protected float _detectionRange;
    [SerializeField] protected float _attackCooldown;   

    public EnemyView EnemyView { get; private set; }

    protected override void Init()
    {
        base.Init();
        EnemyView = (EnemyView)CharacterAnimator;
    }

    public LayerMask GetPlayerMask() 
    {
        return _playerMask; 
    }

    public Vector2 GetDetectionArea()
    {
        return _detectionArea;
    }

    public Transform GetPointA()
    {
        return _pointA;
    }

    public Transform GetPoinB()
    {
        return _pointB;
    }

    public Vector2 GetAttackZone()
    {
        return _attackZone;
    }

    public float GetDetectionRange()
    {
        return _detectionRange;
    }

    public float GetAttackCooldown()
    {
        return _attackCooldown;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_attackPoint.position, _attackZone);
        Gizmos.color = Color.blue;
        Vector2 detectionCube = new Vector2(_detectionRange, _detectionArea.y);
        Gizmos.DrawWireCube(_attackPoint.position, detectionCube);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_pointA.position, _pointB.position);
    }

}
