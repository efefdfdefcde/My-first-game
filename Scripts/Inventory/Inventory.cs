using System;
using System.Collections;
using UnityEngine;




    public class Inventory : MonoBehaviour
    {
        [SerializeField] private PlayerCharacteristics characteristics;

        public Action _healAction;
        public Action<int> _healUpdAction;
        public Action<int> _coinUpdAction;

        private int _healPotionAmount { get; set; }
        private int _coinsAmount { get; set; }
      
      
        private HealChest[] _healChests;
        private CoinChest[] _coinsChests;

       
        private void Start ()
        {
            Coin._coinPickAction += CoinAdd;
            ControlKeys._useHealAction += UseHealPotion;
            _healChests = FindObjectsOfType<HealChest>();
            _coinsChests = FindObjectsOfType<CoinChest>();
            foreach(HealChest hchest in _healChests)
            {
                hchest.Chest_Open_Event += HealPotionAdd;
            }
            foreach (CoinChest cchest in _coinsChests)
            {
                cchest.Chest_Open_Event += CoinAdd;
            }
        }   

        private void UseHealPotion()
        {
            if (_healPotionAmount > 0)
            {
                _healPotionAmount -= 1;
                _healUpdAction.Invoke(_healPotionAmount);
                _healAction.Invoke();
            }
        }

        private void HealPotionAdd(int value)
        {
            _healPotionAmount += value;
            _healUpdAction.Invoke(_healPotionAmount);
           

        }

        private void CoinAdd(int value)
        {
            _coinsAmount += value;
            _coinUpdAction.Invoke(_coinsAmount);
        }

        private void OnDestroy()
        {

            Coin._coinPickAction -= CoinAdd;
            foreach (HealChest chest in _healChests)
            {
                chest.Chest_Open_Event -= HealPotionAdd;
            }
            foreach (CoinChest chest in _coinsChests)
            {
                chest.Chest_Open_Event -= CoinAdd;
            }
            characteristics._bank += _coinsAmount;
            ControlKeys._useHealAction -= UseHealPotion;
        }


    }
