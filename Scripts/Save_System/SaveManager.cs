using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private Transform _savePosition;
    [SerializeField] private GameObject _player;

    public static Action _onLoad;


    private void Start()
    {
        SavePoint._savePosition += SavePlayer;
        LoadButton._loadEvent += LoadPlayer;

    }


    private void SavePlayer(Transform savePosition)
    {
        _savePosition = savePosition;
    }

    private void LoadPlayer()
    {
        if (_savePosition != null)
        {
            if(_player != null)
            {
                _player.SetActive(true);
                _player.transform.position = _savePosition.position;
                _onLoad();
                DeadPlayer deadPlayer = FindObjectOfType<DeadPlayer>();
                Destroy(deadPlayer.gameObject);

            }
           
        }  
        
    }
}
