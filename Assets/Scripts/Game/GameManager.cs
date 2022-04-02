using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public Player player;

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
                Debug.Log("Fim de Jogo");
            else
                Debug.Log("Update da interface");
        }
        #endregion
    }
}

