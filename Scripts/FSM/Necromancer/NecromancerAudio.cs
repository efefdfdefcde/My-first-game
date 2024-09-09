using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerAudio : EnemyAudio
{
    [SerializeField] private AudioClip _spawn;

    public void Spawn()
    {
        _source.PlayOneShot(_spawn);
    }
}
