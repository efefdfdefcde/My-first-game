using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private GameObject _brokenPrefab;
    [SerializeField] private Sprite _state1;
    [SerializeField] private Sprite state_2;
    [SerializeField] private Vector2 shake;
    [SerializeField] private float shake_time;
    [SerializeField] private AudioClip _audio;

    private int attack_amount;
    private Vector2 pos;
    private float current_shake_time;
    private AudioSource _source;

    private SpriteRenderer sprite_renderer;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        pos = transform.position;
    }

    private void Update()
    {
        Shake();
    }


    public void Take_Damage()
    {
        _source.PlayOneShot(_audio);
        attack_amount += 1;
        switch (attack_amount)
        {
            case 1:
                sprite_renderer.sprite = _state1 ;
                current_shake_time = shake_time ;
                break;
            case 2: sprite_renderer.sprite = state_2;
                current_shake_time = shake_time ;
                break;
            case 3:  Instantiate(_brokenPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;

        }
    }

    private void Shake()
    {
        if(current_shake_time >= 0)
        {
            transform.position = pos + Random.insideUnitCircle * shake;
            current_shake_time -= Time.deltaTime;
        }
        else
        {
            transform.position = pos;
        }
       
    }
}
