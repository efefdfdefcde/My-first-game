using Assets.Scripts.Bosses.Boss3;
using System;
using UnityEngine;

public class Boss3Controll : MonoBehaviour
{
    [SerializeField] private Thunder _thunder;

    public Action _circleSpawnAction;
    public Action _thunderSpawnAction;
    public static Action _onDeathAction;

    private void Start()
    {
        _thunder._changeStateAction += CircleState;
        BulletCircle._changeStateAction += ThunderState;
        _circleSpawnAction?.Invoke();
    }

    private void CircleState()
    {
        _circleSpawnAction?.Invoke();
    }

    private void ThunderState()
    {
        _thunderSpawnAction?.Invoke();
    }

    

    private void OnDestroy()
    {
        _thunder._changeStateAction -= CircleState;
        BulletCircle._changeStateAction -= ThunderState;
        _onDeathAction?.Invoke();
    }
}
