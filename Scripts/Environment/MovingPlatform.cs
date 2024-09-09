using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _destinationA;
    [SerializeField] private Transform _destinationB;
    [SerializeField] private float _speed;

    private Transform _destination;
   


    private void Start()
    {
        _destination = _destinationA;
    }

    protected virtual void Update()
    {
        Move();
        
    }

    protected virtual void Move()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, _destination.position, _speed * Time.deltaTime);
        if ((Vector2.Distance(_destination.position, transform.position)) <= 0.2f)
        {
            if (_destination == _destinationA)
            {
                _destination = _destinationB;
            }
            else
            {
                _destination = _destinationA;
            }
        }

    }

   


}
