using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] protected GameObject GameObject;
    [SerializeField] protected  int  _angleRotate;
    [SerializeField] protected int _angle2;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rotate();
        }
    }

    protected void Rotate()
    {
        GameObject.transform.rotation = Quaternion.Euler(0, 0, _angleRotate);
        transform.rotation = Quaternion.Euler(0, 0, _angle2);
    }
}
