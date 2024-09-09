using Assets.Scripts.Bosses.Boss2;
using Assets.Scripts.Bosses.Boss2.Stage2;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss2Controll : MonoBehaviour
{
    [SerializeField] private Stage1 stage1;
    [SerializeField] private Stage2 stage2;
    [SerializeField] private StartDoor _startDoor;
    [SerializeField] private GameObject _rain;
    [SerializeField] private LookPoint _lookPoint;
    [SerializeField] private GameObject _bossUi;

    private void Start()
    {
        Boss._changeStageAction +=  Stage2Change;
        _startDoor._startBatttleAction += StartBattle;
    }

    private void StartBattle()
    {
        _bossUi.SetActive(true);
        stage1.enabled = true;
    }

    private void Stage2Change()
    {
        stage1.enabled = false;
        stage2.enabled = true;
        _rain.SetActive(true);
    }

    private void OnDestroy()
    {
        if(_lookPoint != null && _bossUi != null)
        {
            Destroy(_lookPoint.gameObject);
            Destroy(_bossUi);
            _rain.SetActive(false);
        }  
        Boss._changeStageAction -= Stage2Change;
        _startDoor._startBatttleAction -= StartBattle;
    }
}
