using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Player : MonoBehaviour
    {
        Rigidbody2D playerRb;

        [Header("Life")]
        public int currentLife;
        public int maxLife;

        private void Awake() 
        {
            GetPlayerComponents();
            //UpdatePlayerStats - Based on current player upgrades
            SetUpLife();
        }

        private void GetPlayerComponents()
        {
            playerRb = this.gameObject.GetComponent<Rigidbody2D>();
        }

        private void SetUpLife()
        {
            currentLife = maxLife;
            //UpdateUI
        }

    }
}

