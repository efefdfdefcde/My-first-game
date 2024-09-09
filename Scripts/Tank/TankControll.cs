using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControll : MonoBehaviour
{
    private Rigidbody2D _Rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private float maxVelocity;

    private void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    private void FixedUpdate()
    {
        Controll();
    }

    private void Controll()
    {
        if (Input.GetKey("d"))
        {
            _Rigidbody2D.AddForce(Vector2.right *  _speed);
        }
        if (Input.GetKey("a"))
        {
            _Rigidbody2D.AddForce(Vector2.left * _speed);
        }
        if (_Rigidbody2D.velocity.magnitude >= maxVelocity)
        {
            _Rigidbody2D.velocity = _Rigidbody2D.velocity.normalized * maxVelocity;
        }
    }

    private void OnDisable()
    {
        _Rigidbody2D.velocity = Vector2.zero;
    }
}
