using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadView : MonoBehaviour
{
    [SerializeField] protected Image _reload;



    protected void Reload(float reloadTime, float currentTime)
    {
        _reload.fillAmount = currentTime / reloadTime;
    }
}
