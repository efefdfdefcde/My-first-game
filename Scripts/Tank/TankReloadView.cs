using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankReloadView : ReloadView
{
    [SerializeField] private TankCannon _tankCannon;

    private void Start()
    {
        _tankCannon._reloadAction += Reload;
    }

    private void OnDestroy()
    {
        _tankCannon._reloadAction -= Reload;
    }
}
