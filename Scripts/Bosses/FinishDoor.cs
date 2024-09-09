using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    [SerializeField] private Boss Boss;
    [SerializeField] protected GameObject Door;
    [SerializeField] protected int _angleRotate;

    private void Start()
    {
        Boss._bossDeathAction += OpenDoor;
    }

    private void OpenDoor()
    {
        Door.transform.rotation = Quaternion.Euler(0, 0, _angleRotate);
    }

    private void OnDestroy()
    {
        Boss._bossDeathAction -= OpenDoor;
        
    }
}
