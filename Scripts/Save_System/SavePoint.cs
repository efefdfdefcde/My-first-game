using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    protected AudioSource _source => GetComponent<AudioSource>();

    protected bool _isSave;

    [SerializeField] private GameObject _fire;

    public static Action<Transform> _savePosition; 

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isSave)
        {
            _source.Play();
            _fire.SetActive(true);
            Save();
        }
    }

    protected void Save()
    {
        _isSave = true;
        _savePosition?.Invoke(transform);
    }
}
