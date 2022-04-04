using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public Player player;
        public bool gameRunning = true;

        [Header("Money")]
        public int currentMoney;
        

        private void Awake() 
        {
            if(instance != null)
                Destroy(this);
            else
                instance = this;
        }   

        public GameUI gameUI;

        public void RestartGame()
        {
            Debug.Log("Restart the game");
            gameRunning = true;
            player.SetAlive();
            gameUI.ToggleEndGameUI(false);
        }

        #region MoneyManager
        public void AddMoney(int value)
        {
            currentMoney += value;
            gameUI.UpdateMoney(currentMoney);
        }
        #endregion

        #region Obstacles
        public void TakeDamage(int damage)
        {
            player.currentLife--;
            if(player.currentLife <= 0)
            {
                Debug.Log("Fim  de Jogo");
                gameRunning = false;
                gameUI.ToggleEndGameUI(false);
                player.SetDead();
            }
            else
                Debug.Log("Update da interface");
        }
        #endregion
    }
}

