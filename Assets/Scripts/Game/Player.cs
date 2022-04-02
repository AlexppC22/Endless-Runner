using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Player : MonoBehaviour
    {
        Rigidbody2D playerRb;
        [Header("Jump")]
        public bool canJump = true;
        public float jumpForce;

        [Header("Life")]
        public int currentLife;
        public int maxLife;

        private void Awake() 
        {
            GetPlayerComponents();
            //UpdatePlayerStats - Based on current player upgrades
            SetUpLife();
        }

        private void Update() 
        {
            if(canJump && Input.GetKeyDown(KeyCode.Space))
                Jump();
        }

        private void Jump()
        {
            Debug.Log("AAA");
            this.playerRb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Force);
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

