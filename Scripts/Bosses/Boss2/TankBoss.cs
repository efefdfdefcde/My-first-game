using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2
{
    public class TankBoss : TankManager
    {
        [SerializeField] private Collider2D _colider;

        public static Action<bool> _inTankAction;

        private void Start()
        {
            DeadPlayer._playerDeathEvent += TankDeactivate;
        }

        private void TankDeactivate()
        {
            TankCannon.enabled = false;
            TankControll.enabled = false;
            _inTank = false;
            _colider.enabled = false;
            _inTankAction?.Invoke(false);
        }

        protected override void PlayerAction(bool status)
        {
            _inTankAction?.Invoke(status);
            _colider.enabled = status;
        }

        private void OnDestroy()
        {
            DeadPlayer._playerDeathEvent -= TankDeactivate;
        }
    }
}