using UnityEngine;
using UnityEngine.UI;

public class BossUi : MonoBehaviour
{
    [SerializeField] private Image _bossHealth;

    private void Start()
    {
        Boss._bossHealthChange += HealthChanger;
    }

    private void HealthChanger(float maxHealth, float curentHealth)
    {
        _bossHealth.fillAmount = curentHealth/maxHealth;
    }

    private void OnDestroy()
    {
        Boss._bossHealthChange -= HealthChanger;
    }
}
