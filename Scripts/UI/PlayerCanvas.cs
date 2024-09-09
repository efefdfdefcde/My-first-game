using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
   
    [SerializeField] private Image _healthImage;
    [SerializeField] private Image _healthBackground;
    [SerializeField] private Image _staminaImage;
    [SerializeField] private Image _staminaBackground;
    [SerializeField] private Color _backgroundColor;



    private void OnEnable()
    {
        FindObjectOfType<Player>()._healthToUIAction += HealthChange;
        FindObjectOfType<StaminaPool>()._staminaToUIAction += StaminaChange;
        FindObjectOfType<StaminaPool>()._inRecoverAction += StaminaBackground;
    }

    private void OnDisable()
    {
       
    }

    private void HealthChange(float maxHealth, float currentHealth)
    {
        float normalizedHealth = currentHealth / maxHealth;
        _healthImage.fillAmount = normalizedHealth;
        if(currentHealth <= (maxHealth / 4))
        {
            _healthBackground.color = _backgroundColor;
        }
        else
        {
            _healthBackground.color = Color.black;
        }
    }

    private void StaminaChange(float maxStamina,float currentStamina)
    {
       
        float normalizedStamina = currentStamina / maxStamina;
        _staminaImage.fillAmount = normalizedStamina;
    }

    private void StaminaBackground(bool status)
    {
        if (status)
        {
            _staminaBackground.color = _backgroundColor;
        }
        else
        {
            _staminaBackground.color = Color.black;
        }
    }

}
