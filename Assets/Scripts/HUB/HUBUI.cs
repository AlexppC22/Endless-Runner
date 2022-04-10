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
        
        [SerializeField] TextMeshProUGUI moneyUpradeText;
        int itemValue;
        public int itemID = -1;
        [Header("Upgrade")]
        [SerializeField] GameObject upgradeMenu;
        public UpgradeShopManager upgradeShopManager;
        [SerializeField] TextMeshProUGUI lifeUpgradeHUBText;
        [SerializeField] TextMeshProUGUI speedUpgradeHUBText;
        [SerializeField] TextMeshProUGUI jumpsUpgradeHUBText;

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
            upgradeShopManager.LoadUpgradeManager();
            SetUpMoneyTexts();
            UpdateUpgradeHUBTexts(upgradeShopManager.upgradeManager);
        }

        public void SetUpMoneyTexts()
        {
            moneyHUBText.text = PlayerPrefs.GetInt("Money").ToString();
            moneyShopText.text = PlayerPrefs.GetInt("Money").ToString();
            moneyUpradeText.text = PlayerPrefs.GetInt("Money").ToString();
        }
        public void UpdateUpgradeHUBTexts(UpgradeManager upgradeManager)
        {
            lifeUpgradeHUBText.text = "Players Life: " + (1 + upgradeManager.playerLife) + "/4";
            speedUpgradeHUBText.text = "Players Speed: " + (7 + upgradeManager.gameSpd) + "/10";
            jumpsUpgradeHUBText.text = "Players Jumps: " + (1 + upgradeManager.playerJumps) + "/4";

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
            if(!(PlayerPrefs.GetInt("Money") - itemValue  > 0))
            {
                Debug.Log("Cant buy this item");
                return;
            }

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

            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - itemValue);

            UpdateInvetoryVisuals();
            UpdateInvetoryManager();
            SetUpMoneyTexts();
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

