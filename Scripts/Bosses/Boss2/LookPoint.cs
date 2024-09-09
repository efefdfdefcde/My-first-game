using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2
{
    public class LookPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _boss;
        [SerializeField] private Vector2 _checkZone;
        [SerializeField] private float _lookRange;
        [SerializeField] private LayerMask _playerMask;


        private void Update()
        {
            ChangeScale();
        }

        public void ChangePosition(float xpos)
        {
            transform.position = new Vector3(xpos, transform.position.y);
        }

        

        private void ChangeScale()
        {
            if(_boss != null)
            {
                var player = Physics2D.BoxCast(transform.position, _checkZone, 0, Vector3.left, _lookRange, _playerMask);
                if (player)
                {
                    _boss.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    _boss.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Vector2 cube = new Vector2(_lookRange, _checkZone.y);
            Gizmos.DrawWireCube(transform.position, cube);
        }
    }
}