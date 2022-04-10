using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AgTech
{
    public class UpgradeShopManager : MonoBehaviour
    {
        public UpgradeManager upgradeManager;
        [SerializeField] HUBUI hubUI;
        [HideInInspector] public int upgradeID = -1;
        int upgradeValue;
        Item currentUpgradeSelection;

        [Header("Current Upgrade Increases")]
        int lifeUpgradeIncrease;
        float speedUpgradeIncrease;
        int jumpsUpgradeIncrease;

        [Header("Limit of Upgrade Increases")]
        int lifeUpgradeIncreaseLimit;
        float speedUpgradeIncreaseLimit;
        int jumpsUpgradeIncreaseLimit;

        [Header("UI")]
        [SerializeField] TextMeshProUGUI upgradeDescriptionText;

        

        public void ToggleUpgradeSelection(Item upgrade)
        {
            if(upgrade.id == upgradeID)
            {
                upgradeDescriptionText.text = " ";
                upgradeValue = 0;
                upgradeID = -1;
                currentUpgradeSelection = null;
            }
            else
            {
                SelectUpgrade(upgrade);
            }
        }
        private void SelectUpgrade(Item upgrade)
        {
            currentUpgradeSelection = upgrade;
            upgradeDescriptionText.text = upgrade.description;
            upgradeValue = upgrade.value;
            upgradeID = upgrade.id;
        }
        public void BuyUpgrade()
        {
            if(!(PlayerPrefs.GetInt("Money") - upgradeValue > 0))
                return;

            switch(upgradeID)
            {
                case 0:
                    if (GameManager.instance.upgradeManager.playerLifeLimit > 2)
                    {
                        ToggleUpgradeSelection(currentUpgradeSelection);
                        return;
                    }
                    else
                    {
                        GameManager.instance.upgradeManager.playerLifeLimit++;
                        this.lifeUpgradeIncrease ++;
                    }

                    break;
                case 1:
                    if (GameManager.instance.upgradeManager.gameSpdLimit > 2)
                    {
                        ToggleUpgradeSelection(currentUpgradeSelection);
                        return;
                    }
                    else
                    {
                        GameManager.instance.upgradeManager.gameSpdLimit++;
                        this.speedUpgradeIncrease += 1.5f;
                    }
                    break;
                case 2:
                    if (GameManager.instance.upgradeManager.playerJumpsLimit > 2)
                    {
                        ToggleUpgradeSelection(currentUpgradeSelection);
                        return;
                    }
                    else
                    {
                        GameManager.instance.upgradeManager.playerJumpsLimit++;
                        this.jumpsUpgradeIncrease ++;
                    }
                    break;
            }
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - upgradeValue);
            UpdateUpgradeManager();
            hubUI.UpdateUpgradeHUBTexts(upgradeManager);
            hubUI.SetUpMoneyTexts();
        }

        public void LoadUpgradeManager()
        {
            this.lifeUpgradeIncrease = upgradeManager.playerLife;
            this.speedUpgradeIncrease = upgradeManager.gameSpd;
            this.jumpsUpgradeIncrease = upgradeManager.playerJumps;
        }
        private void UpdateUpgradeManager()
        {
            upgradeManager.playerLife = this.lifeUpgradeIncrease;
            upgradeManager.gameSpd = this.speedUpgradeIncrease;
            upgradeManager.playerJumps = this.jumpsUpgradeIncrease;
        }
    }
}

