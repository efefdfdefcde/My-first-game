using Assets.Scripts.Bosses.Boss2;
using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss3
{
    public class Boss3Manager : MonoBehaviour
    {

        [SerializeField] private StartDoor _startDoor;
        [SerializeField] private Boss3Controll _boss;
        [SerializeField] private Transform _cameraPoint;
        [SerializeField] private CinemachineVirtualCamera _followCamera;
        [SerializeField] private GameObject _bossUI;

        private void Start()
        {
            _startDoor._startBatttleAction += BattleStart;
        }

        private void BattleStart()
        {
            _bossUI.SetActive(true);
            _boss.enabled = true;
            _followCamera.Follow = _cameraPoint;
        }

        private void OnDestroy()
        {
            _bossUI.SetActive(false);
            _startDoor._startBatttleAction -= BattleStart;
        }
    }
}