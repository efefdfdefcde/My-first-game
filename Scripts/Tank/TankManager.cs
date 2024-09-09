using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    [SerializeField] protected TankCannon TankCannon;
    [SerializeField] protected TankControll TankControll;
    [SerializeField] protected Transform _playerChecker;
    [SerializeField] protected Vector2 _playerCheckZone;
    [SerializeField] protected LayerMask _playerMask;
    [SerializeField] protected GameObject _player;
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    [SerializeField] private Vector3 _newFollowOffset;
    [SerializeField] private Vector3 _oldFollowOffset;
    [SerializeField] private GameObject _tankReloadView;

    protected bool _inTank;

   

    private void Update()
    {
        TankActivate();
    }

    protected void TankActivate()
    {
        if (Input.GetKeyDown("f"))
        {
            Collider2D player = Physics2D.OverlapBox(_playerChecker.position, _playerCheckZone, 0, _playerMask);
            bool status = false;
            if (player != null)
            {
                status = true; 
                _player.SetActive(false);
                PlayerAction(status);
            }
            else if (_inTank)
            {
                _player.SetActive(true);
                status = false;
                _player.transform.position = _playerChecker.position;
                PlayerAction(status);
            }
          
            _tankReloadView.SetActive(status);
            TankCannon.enabled = status;
            TankControll.enabled = status;
            _inTank = status;
      
        }



    }

    protected virtual void PlayerAction(bool status)
    {
        if (status)
        {
           
            _followCamera.Follow = transform;
            _followCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = _newFollowOffset;
        }
        else
        {
           
          
            _followCamera.Follow = _player.transform;
            _followCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = _oldFollowOffset;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_playerChecker.position,_playerCheckZone);
    }
}
