using Assets.Scripts.Bosses.Boss2.Stage1;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2.Stage2
{
    public class Stage2 : MonoBehaviour
    {
        [SerializeField] private PointPosition[] _safePoints;
        [SerializeField] private LookPoint _lookPoint;

        private Boss2Audio _audio;
        private PositionChanger _positionChanger;

        private void Start()
        {
            _positionChanger = new(_safePoints,transform,_lookPoint);
            _positionChanger.ChangePosition();
            _audio = GetComponent<Boss2Audio>();
            _audio.ChangePosition();
            Boss._bossHealthChange += ChangePosition;
        }

        private void ChangePosition(float none,float non)
        {
            _audio.ChangePosition();
            _positionChanger.ChangePosition();
        }
    }
}