using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2
{
    public class BossManager : MonoBehaviour
    {
        [SerializeField] private StartDoor _startDoor;
        [SerializeField] private Transform _cameraPoint1;
        [SerializeField] private Transform _cameraPoint2;
        [SerializeField] private CinemachineVirtualCamera _followCamera;
        [SerializeField] private Collider2D _door2;
        [SerializeField] private Stage2Door _stage2Door;
        [SerializeField] private GameObject _player;
        [SerializeField] private TankControll _tankControll;
        [SerializeField] private TankCannon _tankCannon;
        [SerializeField] private TankBoss _tankBoss;

        private void Start()
        {
            _startDoor._startBatttleAction += CameraPoint1;
            Boss._changeStageAction += Stage2;
            
            _stage2Door._stage2DoorAction += CameraPoint2;
        }

        private void CameraPoint1()
        {
            _followCamera.Follow = _cameraPoint1;
        }

        private void CameraPoint2()
        {
            _followCamera.Follow = _cameraPoint2;   
        }

        private void Stage2()
        {
            _door2.enabled = false;
            if(_player != null)
            {
                _player.SetActive(true);
                _tankBoss.enabled = false;
                _tankControll.enabled = false;
                _tankCannon.enabled = false;
            }
        }

        private void OnDestroy()
        {
            _startDoor._startBatttleAction -= CameraPoint1;
            Boss._changeStageAction -= Stage2;
            _stage2Door._stage2DoorAction -= CameraPoint2;
        }


    }
}