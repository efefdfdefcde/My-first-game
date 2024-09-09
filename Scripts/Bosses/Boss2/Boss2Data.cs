using System.Collections;
using UnityEngine;


public class Boss2Data : Data
{
    [SerializeField] private float _cooldown;

    public float GetCooldown()
    {
        return _cooldown;
    }

}
