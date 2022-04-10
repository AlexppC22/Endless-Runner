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
            endGameMoneyText.text = currentMoney.ToString();
        }

        public void UpdateLifeDots()
        {
            for(int i = 0; i < lifeDots.Length; i++)
            {
                if(i < GameManager.instance.player.currentLife)
                    lifeDots[i].gameObject.SetActive(true);
                else
                    lifeDots[i].gameObject.SetActive(false);
            }
        }

        public void ToggleEndGameUI(bool toggle)
        {
            endGameUI.SetActive(toggle);
        }

        public void HUBButton()
        {
            SceneManager.LoadScene(2);
        }   
        public void RetryButton()
        {
            GameManager.instance.RestartGame();
        }
    }
}

