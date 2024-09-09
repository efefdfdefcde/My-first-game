using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private PlayerView _playerView;
    private float _speed;
    private Transform _transform ;
    private  float _horizontal;
    private GroudChecker GroudChecker;
   
    

    public WalkState(PlayerView playerView, float speed, Transform transform, GroudChecker groudChecker)
    {
        _playerView = playerView;
        _speed = speed;
        _transform = transform;
        GroudChecker = groudChecker;
    }

   

    public override void Update()
    {
        Walk();
        
    }

    private void Walk()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _playerView.Move(_horizontal, GroudChecker.Check());
        Vector3 step = new Vector3(_horizontal, 0, 0);
        _transform.position += step * Time.deltaTime * _speed;
    }

   
}
