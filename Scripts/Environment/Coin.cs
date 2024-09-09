using System;
using System.Collections;
using UnityEngine;



public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue;
    [SerializeField] private Rigidbody2D _coinRigidbody;
    [SerializeField] private GameObject _coinParent;

    public static Action<int> _coinPickAction;
   

    private void Start()
    {
       
        _coinRigidbody.AddForce(new Vector2(0, 5f),ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _coinPickAction?.Invoke(_coinValue);
            Destroy(_coinParent);
            Destroy(gameObject);
        }
    }

}
