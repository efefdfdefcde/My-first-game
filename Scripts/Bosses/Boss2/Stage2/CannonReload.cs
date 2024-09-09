using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonReload : ReloadView
{
    [SerializeField] private CannonBoss _cannonBoss;

    private void Start()
    {
        _cannonBoss._reloadAction += Reload;
    }

    private void OnDestroy()
    {
        _cannonBoss._reloadAction -= Reload;
    }
}
