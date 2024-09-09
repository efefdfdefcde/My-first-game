using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Manager : MonoBehaviour
{
    [SerializeField] private PlayerCharacteristics characteristics;
    [SerializeField] private int price;
    [SerializeField] private int hp_upgrade_ammount;
    [SerializeField] private int stamina_upgrade_ammount;
    [SerializeField] private int damage_upgrade_ammount;
    [SerializeField] private AudioClip _clip;

    private Upgrade_View view;
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        view = GetComponent<Upgrade_View>();
        view.Initialization(price, hp_upgrade_ammount, stamina_upgrade_ammount, damage_upgrade_ammount);
    }

    private enum UpgradeType
    {
        Hp,
        Stamina,
        Damage
    }

    public void HpUpgrade()
    {
       Upgrade(UpgradeType.Hp);
    }

    public void StaminaUpgrade()
    {
        Upgrade(UpgradeType.Stamina);
    }

    public void DamageUpgrade()
    {
        Upgrade(UpgradeType.Damage);
    }

    private void Upgrade(UpgradeType type)
    {
        if(characteristics._bank >= price)
        {
            characteristics._bank -= price;
            switch (type)
            {
                case UpgradeType.Hp:
                    characteristics._maxHealth += hp_upgrade_ammount;
                    view.Hp_Upgrade(hp_upgrade_ammount);
                    break;
                case UpgradeType.Stamina:
                    characteristics._maxStamina += stamina_upgrade_ammount;
                    view.Stamina_Upgrade(stamina_upgrade_ammount);
                    break;
                case UpgradeType.Damage:
                    characteristics._damage += damage_upgrade_ammount;
                    view.Damage_Upgrade(damage_upgrade_ammount);
                    break;


            }
            _source.PlayOneShot(_clip);
        }
    }
}
