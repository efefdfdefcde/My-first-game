using Assets.Scripts;
using System;
using UnityEngine;



public class EnemyPatrollingState : State
{
    private EnemyView _EnemyView;
    private Transform _transform;
    private Transform _pointA;
    private Transform _pointB;
    private Transform _currentPoint;
    private float _speed;
    private float _patrollDistance = 1f;

    public EnemyPatrollingState(EnemyView enemyView , Transform transform, Transform pointA, Transform pointB, float speed)
    {
        _EnemyView = enemyView;
        _transform = transform;
        _pointA = pointA;
        _pointB = pointB;
        _speed = speed;
    }

    public override void Enter()
    {
        _currentPoint = _pointA;
    }

    public override void Update()
    {
        Patrolling();
    }

    private void Patrolling()
    {

        _EnemyView.Move();
        Vector3 move = new Vector3(_currentPoint.position.x - _transform.position.x,0,0).normalized;
        _transform.localScale = new Vector3(move.x * -1, 1, 1);
        _transform.position += move * Time.deltaTime * _speed;
        if ((Vector2.Distance(_currentPoint.position, _transform.position)) <= _patrollDistance)
        {
            if (_currentPoint == _pointA)
            {
                _currentPoint = _pointB;
            }
            else
            {
                _currentPoint = _pointA;
            }
        }
    }
}
