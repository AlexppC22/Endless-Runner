using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace AgTech
{
    public class HUBUI : MonoBehaviour
    {
        [Header("Shop")]
        [SerializeField] GameObject shopMenu;
        [SerializeField] TextMeshProUGUI descriptionText;
        [SerializeField] TextMeshProUGUI moneyShopText;
        [SerializeField] TextMeshProUGUI moneyHUBText;
        int itemValue;
        public int itemID = -1;
        [Header("Upgrade")]
        [SerializeField] UpgradeManager upgradeManager;
        [SerializeField] int upgrade0Increase;
        [SerializeField] int upgrade1Increase;
        [SerializeField] int upgrade2Increase;
        [SerializeField] GameObject upgradeMenu;
        [SerializeField] TextMeshProUGUI upgradeDescriptionText;
        [SerializeField] TextMeshProUGUI moneyUpradeText;
        public int upgradeID = -1;
        int upgradeValue;

        [Header("Inventory")]
        [SerializeField] InventoryManager inventory;
        [SerializeField] int item0Quantity;
        [SerializeField] int item1Quantity;
        [SerializeField] int item2Quantity;
        [SerializeField] int item3Quantity;
        [SerializeField] TextMeshProUGUI item0QuantityText;
        [SerializeField] TextMeshProUGUI item1QuantityText;
        [SerializeField] TextMeshProUGUI item2QuantityText;
        [SerializeField] TextMeshProUGUI item3QuantityText;
        
        

        private void Start() 
        {
            LoadInventoryData();
            LoadUpgradeManager();
            moneyHUBText.text = PlayerPrefs.GetInt("Money").ToString();
            moneyShopText.text = PlayerPrefs.GetInt("Money").ToString();
        }

        #region Inventory
        private void LoadInventoryData()
        {
            Debug.Log("Loads all the info from the scriptable object");
            this.item0Quantity = inventory.item0Quantity;
            this.item1Quantity = inventory.item1Quantity;
            this.item2Quantity = inventory.item2Quantity;
            this.item3Quantity = inventory.item3Quantity;
            UpdateInvetoryVisuals();
        }
        private void UpdateInvetoryVisuals()
        {
            this.item0QuantityText.text = this.item0Quantity.ToString();
            this.item1QuantityText.text = this.item1Quantity.ToString();
            this.item2QuantityText.text = this.item2Quantity.ToString();
            this.item3QuantityText.text = this.item3Quantity.ToString();
        }
        private void UpdateInvetoryManager()
        {
            inventory.item0Quantity = this.item0Quantity;
            inventory.item1Quantity = this.item1Quantity;
            inventory.item2Quantity = this.item2Quantity;
            inventory.item3Quantity = this.item3Quantity;
        }
        #endregion

        #region Shop
        private void SelectItem(Item item)
        {
            descriptionText.text = item.description;
            itemValue = item.value;
            itemID = item.id;
        }

        public void ToogleItemSelection(Item receveidItem)
        {
            if(receveidItem.id == itemID)
            {
                descriptionText.text = " ";
                itemID = -1;
            }
            else
            {
                SelectItem(receveidItem);
            }
        }   

        public void BuyItem()
        {
            if(!(itemValue - PlayerPrefs.GetInt("Money") > 0))
                return;

            switch(itemID)
            {
                case 0:
                    this.item0Quantity ++;
                    break;
                case 1:
                    this.item1Quantity ++;
                    break;
                case 2:
                    this.item2Quantity ++;
                    break;
                case 3:
                    this.item3Quantity ++;
                    break;
            }
            UpdateInvetoryVisuals();
            UpdateInvetoryManager();
        }
        #endregion
        #region Upgrade
        public void ToggleUpgradeSelection(Item upgrade)
        {
            if(upgrade.id == upgradeID)
            {
                upgradeDescriptionText.text = " ";
                upgradeID = -1;
            }
            else
            {
                SelectUpgrade(upgrade);
            }
        }
        private void SelectUpgrade(Item upgrade)
        {
            upgradeDescriptionText.text = upgrade.description;
            upgradeValue = upgrade.value;
            upgradeID = upgrade.id;
        }
        public void BuyUpgrade()
        {
            if(!(upgradeValue - PlayerPrefs.GetInt("Money") > 0))
                return;

            switch(upgradeID)
            {
                case 0:
                    this.item0Quantity ++;
                    break;
                case 1:
                    this.item1Quantity ++;
                    break;
                case 2:
                    this.item2Quantity ++;
                    break;
            }
            UpdateInvetoryManager();
        }
        private void LoadUpgradeManager()
        {
            this.upgrade0Increase = upgradeManager.playerLife;
            this.upgrade1Increase = upgradeManager.gameSpd;
            this.upgrade2Increase = upgradeManager.playerJumps;
        }
        private void UpdateUpgradeManager()
        {
            upgradeManager.playerLife = this.upgrade0Increase;
            upgradeManager.gameSpd = this.upgrade1Increase;
            upgradeManager.playerJumps = this.upgrade2Increase;
        }
        #endregion
        public void LoadMenu()
        {
            SceneManager.LoadScene(0);
        }
        
        public void LoadGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ToggleUpgradeMenu()
        {
            if(shopMenu.activeInHierarchy) 
            {
                shopMenu.SetActive(false);
            }
            upgradeMenu.SetActive(!upgradeMenu.activeInHierarchy);
        }

        public void ToggleShopMenu()
        {
            if(upgradeMenu.activeInHierarchy) 
            {
                upgradeMenu.SetActive(false);
            }
            shopMenu.SetActive(!shopMenu.activeInHierarchy);

        }
    }
}

