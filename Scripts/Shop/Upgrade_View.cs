using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade_View : MonoBehaviour
{
    [SerializeField] private PlayerCharacteristics characteristics;
    [SerializeField] private ParticleSystem hp_particles;
    [SerializeField] private ParticleSystem stamina_particles;
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private TextMeshProUGUI stamina;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI bank;
    public void Hp_Upgrade(int hp_upgrade_ammount)
    {
        hp_particles.Play();
        hp.text = characteristics._maxHealth.ToString() + "+" + hp_upgrade_ammount.ToString();
        bank.text = characteristics._bank.ToString();
    }

    public void Stamina_Upgrade(int stamina_upgrade_ammount)
    {
        stamina_particles.Play();
        stamina.text = characteristics._maxStamina.ToString() + "+" + stamina_upgrade_ammount.ToString();
        bank.text = characteristics._bank.ToString();
    }

    public void Damage_Upgrade(int damage_upgrade_ammount)
    {
        animator.Play("Player_Attack3 1");
        damage.text = characteristics._damage.ToString() + "+" + damage_upgrade_ammount.ToString();
        bank.text = characteristics._bank.ToString();
    }

    public void Initialization(int price, int hp_upgrade_ammount, int stamina_upgrade_ammount, int damage_upgrade_ammount)
    {
        this.price.text = price.ToString();
        bank.text = characteristics._bank.ToString();
        hp.text = characteristics._maxHealth.ToString() + "+" + hp_upgrade_ammount.ToString();
        stamina.text = characteristics._maxStamina.ToString() + "+" + stamina_upgrade_ammount.ToString();
        damage.text = characteristics._damage.ToString() + "+" + damage_upgrade_ammount.ToString();
    }
}
