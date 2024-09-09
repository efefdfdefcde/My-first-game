using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MovingStar
{
    [SerializeField] private float rotation_speed;
    [SerializeField] private Sprite _blodySaw;

    private SpriteRenderer _renderer;

    protected override void Start()
    {
        base.Start();
        _renderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        Saw_Rotation();
        
    }

    private void Saw_Rotation()
    {
        transform.Rotate(0,0,rotation_speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Player"))
        {
            _renderer.sprite = _blodySaw;
        }
           
    }
}
