using System.Collections;
using UnityEngine;
using TMPro;
using Assets.Scripts;


public class InventoryUI : MonoBehaviour
{
        [SerializeField] private TextMeshProUGUI _healAmountView;
        [SerializeField] private TextMeshProUGUI _coinsAmountView;

        private void Start()
        {
            Inventory inventory = FindObjectOfType<Inventory>();
            inventory._healUpdAction += HealPotUpdate;
            inventory._coinUpdAction += CoinsUpdate;
        }

        private void HealPotUpdate(int amount)
        {
            _healAmountView.text = amount.ToString();
        }

        private void CoinsUpdate(int amount)
        {
            _coinsAmountView.text = amount.ToString();
        }
}
