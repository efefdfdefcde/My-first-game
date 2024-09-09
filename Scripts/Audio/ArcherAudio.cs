using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAudio : EnemyAudio
{
    [SerializeField] private AudioClip _shot;

    public void Shot()
    {
        _source.PlayOneShot(_shot);
    }
}
