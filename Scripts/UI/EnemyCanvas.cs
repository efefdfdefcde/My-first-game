using Characters;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class EnemyCanvas : MonoBehaviour
    {

        [SerializeField] private GameObject _enemyCanvas;
        [SerializeField] private Image _health;
        [SerializeField] private Enemy _enemy;

        private void Start()
        {
            _enemy._UIUpdateAction += UIUpdate;
        }


        private void UIUpdate(float maxHealth, float currentHealth)
        {
            if(!_enemyCanvas.activeSelf)_enemyCanvas.SetActive(true);
            _health.fillAmount = currentHealth/maxHealth;
        }

        private void OnDestroy()
        {
            _enemy._UIUpdateAction += UIUpdate;
        }
    }
}