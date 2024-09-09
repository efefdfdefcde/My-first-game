using Assets.FSM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private int _healStrenght;
    [SerializeField] private ParticleSystem _blockEffect;
    [SerializeField] private ParticleSystem _healEffect;
    [SerializeField] protected ParticleSystem _bloodEffect;
    private bool _inBlock;
    private Inventory inventory;
    private PlayerAudio _audio => GetComponent<PlayerAudio>();

    public Action<float,float> _healthToUIAction;

    private void Start()
    {
        SaveManager._onLoad += OnLoad;
        _maxHealth = GetComponent<PlayerData>().MaxHealth;
        _currentHealth = _maxHealth;
        inventory = FindObjectOfType<Inventory>();
        inventory._healAction += Heal;
        BlockState._blockStatusAction += ChangeBlock;
    }

    public override void TakeDamage(float damage)
    {
        if (_inBlock)
        {
            _blockEffect.Play();
            _audio.Block();
        }
        else
        {
            base.TakeDamage(damage);
            _audio.Damage();
        }
    }

    protected override void OnDamage()
    {
        _bloodEffect.Play();
        _healthToUIAction.Invoke(_maxHealth, _currentHealth);
    }

    protected override void OnDeath()
    {
        GameObject dead = Instantiate(_deadCharacter, transform.position, Quaternion.identity);
        Vector3 characterScale = gameObject.transform.localScale;
        dead.transform.localScale = characterScale;
        _audio.Death();
        gameObject.SetActive(false);
    }


    private void ChangeBlock(bool inBlock)
    {
        _inBlock = inBlock;
    }

    private void Heal()
    {
        _healEffect.Play();
        _audio.Heal();
        _currentHealth += _healStrenght;
        _currentHealth = Math.Clamp(_currentHealth, 0, _maxHealth);
        _healthToUIAction.Invoke(_maxHealth, _currentHealth);
    }

    private void OnLoad()
    {
        _currentHealth = _maxHealth;
        _audio.Load();
        _healthToUIAction.Invoke(_maxHealth, _currentHealth);
    }

    private void OnDestroy()
    {
        inventory._healAction -= Heal;
        BlockState._blockStatusAction -= ChangeBlock;
        SaveManager._onLoad -= OnLoad;
    }
}
