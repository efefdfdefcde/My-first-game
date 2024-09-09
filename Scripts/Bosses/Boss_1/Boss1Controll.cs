using Assets.NewScripts.FSM.Enemy;
using Assets.Scripts.Bosses.Boss_1;
using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class Boss1Controll : MonoBehaviour
    {
        [SerializeField] private Stage1 Stage1;
        [SerializeField] private Stage2 Stage2;
        [SerializeField] private Stage3 Stage3;
        [SerializeField] private GameObject _bossUI;
        [SerializeField] private Boss1Rotator _bossRotator;
        [SerializeField] private Transform _cameraPoint;
        [SerializeField] private CinemachineVirtualCamera followCamera;

        private void Start()
        {
            Boss._changeStageAction += Stage2Change;
            Stage2._changeStateAction += Stage3Change;
            _bossRotator._batleBeginAction += BatleStart;
        }

        private void BatleStart()
        {
            Stage1.enabled = true;
            _bossUI.SetActive(true);
            followCamera.Follow = _cameraPoint;
        }

        private void Stage2Change()
        {
            Boss._changeStageAction -= Stage2Change;
            Stage1.enabled = false;
            Stage2.enabled = true;
        }

        private void Stage3Change()
        {
            Stage2._changeStateAction -= Stage3Change;
            Stage2.enabled = false;
            Stage3.enabled = true;
        }

        private void OnDestroy()
        {
            
           
            _bossRotator._batleBeginAction -= BatleStart;
            if(_bossUI != null)
            {
                _bossUI.gameObject.SetActive(false);
            }
           
        }
    }
}