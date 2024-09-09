using Assets.Scripts.Bosses;
using System;
using UnityEngine;

public class Boss : Character
{

    [SerializeField] private ParticleSystem _blood;

    private BossAudio _bossAudio => GetComponent<BossAudio>();

    public static Action<float, float> _bossHealthChange;
    public static Action _changeStageAction;
    public Action _bossDeathAction;

    private void Start()
    {
        _maxHealth = GetComponent<Data>().MaxHealth;
        _currentHealth = _maxHealth;
    }


    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        _bossAudio.Damage();
        _bossHealthChange?.Invoke(_maxHealth,_currentHealth);
        if (_currentHealth <= _maxHealth / 2) _changeStageAction?.Invoke();
    }

    protected override void OnDamage()
    {
        _blood.Play();
    }

    protected override void OnDeath()
    {
        _bossAudio.Death();
        _bossDeathAction?.Invoke();
        base.OnDeath();   
    }
}
