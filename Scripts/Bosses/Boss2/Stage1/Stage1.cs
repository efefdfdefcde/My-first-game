using Assets.Scripts.Bosses.Boss2;
using Assets.Scripts.Bosses.Boss2.Stage1;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    [SerializeField] private int _attackNumber;
    [SerializeField] private PointPosition[] _positions;
    [SerializeField] private ParticleSystem _moveEffect;
    [SerializeField] private Spirit _spiritPrefab;
    [SerializeField] private LookPoint _lookPoint;

    


    private float _currentTime;
    private float _attackCooldown;
    private int _attackCount;
    private Transform _attackPoint;
    private Boss2View _view;
    private Transform _player;
    private Transform _tank;
    private Boss2Data _data;
    private PositionChanger _positionChanger;
    private Boss2Audio _audio;
    private bool _inTank;


    private void Start()
    {
        _moveEffect.Play();
        _moveEffect.transform.SetParent(null);
        _positionChanger = new PositionChanger(_positions,transform,_lookPoint);
        _player = FindObjectOfType<Player>().transform;
        _tank = FindObjectOfType<Tank>().transform;
        _data = GetComponent<Boss2Data>();
        _attackCooldown = _data.GetCooldown();
        _attackPoint = _data.GetAttackPoint();  
        _view = GetComponent<Boss2View>();
        _positionChanger.ChangePosition();
        _audio = GetComponent<Boss2Audio>();
        TankBoss._inTankAction += TankStatus;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Time.time >= _currentTime)
        {
            _currentTime = Time.time + _attackCooldown;
            _view.Attack1();
        }
    }

    private void DealDamage() //AnimationCall
    {
        _audio.Spirit();
        var spiritGO = Instantiate(_spiritPrefab,_attackPoint.position,Quaternion.identity);
        spiritGO.transform.localScale = transform.localScale;
        Spirit spirit = spiritGO.GetComponent<Spirit>();
        if (_inTank)
        {
            spirit.Direction = (_tank.transform.position - transform.position).normalized;
        }
        else
        {
            spirit.Direction = (_player.position - transform.position).normalized;
        }
        spirit.Damage = _data.Damage;
        _attackCount++;
        if (_attackCount == _attackNumber)
        {
            _positionChanger.ChangePosition();
            _audio.ChangePosition();
            _attackCount = 0;
        }
    }

    private void TankStatus(bool status)
    {
        _inTank = status;
    }

   
}
