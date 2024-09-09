using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStar : Trap
{

    [SerializeField] private Transform destinationA;
    [SerializeField] private Transform destinationB;
    [SerializeField] private float speed;

    private Transform destination;

    protected virtual void Start()
    {
        destination = destinationA;
    }

    protected virtual void Update()
    {
        Move();

    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        if ((Vector2.Distance(destination.position, transform.position)) <= 0.2f)
        {
            if (destination == destinationA)
            {
                destination = destinationB;
            }
            else
            {
                destination = destinationA;
            }
        }

    }
}
