using Assets.Scripts;
using System.Collections;
using UnityEngine;


namespace Assets.NewScripts.FSM.Enemy.States
{
    public class EnemyPersuitState : State
    {
        private EnemyView EnemyView;
        private Collider2D _player;
        private Transform _transform;
        private float _speed;
        private EnemyControll _EnemyControll;

        public EnemyPersuitState(EnemyView enemyView, Transform transform, float speed, EnemyControll enemyControll)
        {
            EnemyView = enemyView;
            _transform = transform;
            _speed = speed;
           
            _EnemyControll = enemyControll;
            _EnemyControll.persuitInfoAction += FindPlayer;
        }

        public override void Exit()
        {

        }

        public override void Update()
        {
            Persuit();
        }

        private void Persuit()
        {
            EnemyView.Move();
            Vector3 playerPosition = (_player.transform.position - _transform.position).normalized;
            if (playerPosition.x > 0) _transform.localScale = new Vector3(-1, 1, 1);
            if (playerPosition.x < 0) _transform.localScale = new Vector3(1, 1, 1);
            _transform.position += playerPosition * Time.deltaTime * _speed;
        }

        private void FindPlayer(Collider2D player)
        {
            _player = player;
        }

        public void OnDestroy()
        {
            _EnemyControll.persuitInfoAction -= FindPlayer;
        }
    }
}