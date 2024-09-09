using UnityEngine;
using Assets.Scripts.Bosses.Boss2.Stage1;

namespace Assets.Scripts.Bosses.Boss2
{
    public class PositionChanger
    {

        private PointPosition[] _positions;
        private int _currentPosition;
        private int _nextPosition;
        private Transform _transform;
        private LookPoint _lookPoint;

        public PositionChanger(PointPosition[] positions, Transform transform, LookPoint lookPoint)
        {
            _positions = positions;
            _transform = transform;
            _lookPoint = lookPoint;
        }

        public void ChangePosition()
        {
            GetPosition();
            _positions[_currentPosition]._moveEffect.Play();
            _currentPosition = _nextPosition;
            _positions[_currentPosition]._moveEffect.Play();
            _transform.position = _positions[_currentPosition].transform.position;
            _lookPoint.ChangePosition(_positions[_currentPosition].transform.position.x);

        }

        public void GetPosition()
        {
            int pos;
            while (true)
            {
                pos = Random.Range(0, _positions.Length);
                if (pos != _currentPosition) { _nextPosition = pos; break; }
            }
        }
    }
}
