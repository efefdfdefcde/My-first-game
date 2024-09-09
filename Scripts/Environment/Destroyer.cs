using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _lifetime;

    private void Update()
    {
        _lifetime -= Time.deltaTime;
        if (_lifetime < 0 )Destroy(gameObject);
    }
}
