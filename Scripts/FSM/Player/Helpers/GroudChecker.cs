using System.Collections;
using UnityEngine;
using System;



public class GroudChecker
{
    private Transform _transform;
    private Vector2 _size;
    private LayerMask _ground;

    public GroudChecker(Transform transform, Vector2 size, LayerMask ground)
    {
        _transform = transform;
        _size = size;
        _ground = ground;
    }
    public bool Check()
    {
        bool onGround;
        onGround = Physics2D.BoxCast(_transform.position, _size, 0, Vector2.down, 0.1f, _ground);
        return onGround;
    }
}
