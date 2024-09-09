using Assets.Scripts.Bosses;
using UnityEngine;

public class Boss1Audio : BossAudio
{
    [SerializeField] private AudioClip _wind, _smoke, _gas, _attack;

    public void Wind()
    {
        _source.PlayOneShot(_wind);
    }

    public void Smoke()
    {
        _source.PlayOneShot(_smoke);
    }

    public void Gas()
    {
        _source.PlayOneShot(_gas);
    }

    public void Attack()
    {
        _source.PlayOneShot(_attack);
    }
}
