using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace AgTech
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI moneyText;
        [SerializeField] TextMeshProUGUI endGameMoneyText;
        [Header("LifeUI")]
        public Image[] lifeDots;

        [Header("EndGameUI")]
        public GameObject endGameUI;

        public void UpdateMoney(int currentMoney)
        {
            moneyText.text = currentMoney.ToString();
        }

        public void UpdateLifeDots()
        {
            
        }

        public void ToggleEndGameUI(bool toggle)
        {
            endGameUI.SetActive(toggle);
        }

        public void HUBButton()
        {
            //Load HUB Scene
            Debug.Log("Go to HUB");
            SceneManager.LoadScene(2);
        }   
        public void RetryButton()
        {
            Debug.Log("Restart the game");
            GameManager.instance.RestartGame();
        }
    }
}

