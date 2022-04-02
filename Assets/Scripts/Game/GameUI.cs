using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AgTech
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI moneyText;
        [Header("LifeUI")]
        public Image[] lifeDots;
        public void UpdateMoney(int currentMoney)
        {
            moneyText.text = currentMoney.ToString();
        }

        public void UpdateLifeDots()
        {
            
        }
    }
}

