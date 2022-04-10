using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        public static GameManager instance;
        public Player player;
        public GameUI gameUI;
        public bool gameRunning = true;

        [Header("Money")]
        public int currentMoney;

        [Header("Upgrades")]
        public UpgradeManager upgradeManager;
        

        private void Awake() 
        {
            if(instance != null)
                Destroy(this);
            else
                instance = this;
            
            currentMoney = PlayerPrefs.GetInt("Money");
            AddMoney(0);
        }
           
        private void Start() 
        {
            gameUI.UpdateLifeDots();    
        }

        public void RestartGame()
        {
            gameRunning = true;
            player.SetAlive();
            gameUI.ToggleEndGameUI(false);
            gameUI.UpdateLifeDots();
        }

        #region MoneyManager
        public void AddMoney(int value)
        {
            currentMoney += value;
            PlayerPrefs.SetInt("Money", currentMoney);
            gameUI.UpdateMoney(currentMoney);
        }
        #endregion

        #region Obstacles
        public void TakeDamage(int damage)
        {
            player.currentLife--;
            if(player.currentLife <= 0)
            {
                gameRunning = false;
                gameUI.ToggleEndGameUI(true);
                player.SetDead();
            }
            else
                gameUI.UpdateLifeDots();
        }
        #endregion
    }
}

