using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AgTech
{
    public class ShopManager : MonoBehaviour
    {
        [Header("Shop")]
        [SerializeField] GameObject shopMenu;
        [SerializeField] TextMeshProUGUI descriptionText;
        [SerializeField] TextMeshProUGUI moneyShopText;
        [SerializeField] TextMeshProUGUI moneyHUBText;
        int itemValue;
        public int itemID = -1;

        private void SelectItem(Item item)
        {
            descriptionText.text = item.description;
            itemValue = item.value;
            itemID = item.id;
        }
    }
}

