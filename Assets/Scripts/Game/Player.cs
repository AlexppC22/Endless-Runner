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
        public int numberOfJumps;
        public int maxNumberOfJumps;
        public BoxCollider2D boxCollider2D;
        [SerializeField] private LayerMask groundLayerMask;

        [Header("Life")]
        public int currentLife;
        public int maxLife;
        public bool isDead;

        #region Unity Functions
        private void Awake() 
        {
            GetPlayerComponents();
            SetUpJumps();
            SetUpLife();
        }
        private void Update() 
        {
            if(canJump && Input.GetKeyDown(KeyCode.Space) && !isDead)
                JumpCheck();
        }
        #endregion
        private bool IsGrounded()
        {
            RaycastHit2D rayHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + 0.5f, groundLayerMask);
            
            if(rayHit.collider != null)
                return true;
            
            else 
                return false;
            
        }
        #region PlayerSetups
        private void GetPlayerComponents()
        {
            playerRb = this.gameObject.GetComponent<Rigidbody2D>();
        }
        private void SetUpJumps()
        {
            maxNumberOfJumps = 1 + GameManager.instance.upgradeManager.playerJumps;
            numberOfJumps = maxNumberOfJumps;
        }

        private void SetUpLife()
        {
            maxLife = 1 + GameManager.instance.upgradeManager.playerLife;
            currentLife = maxLife;
            //UpdateUI
        }
        #endregion
        #region Player Life/Death
        public void SetDead()
        {
            isDead = true;
            currentLife = 0;
        }
        public void SetAlive()
        {
            isDead = false;
            currentLife = maxLife;
        }
        #endregion
        private void Jump()
        {
            this.playerRb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Force);
        }

        private void JumpCheck()
        {
            numberOfJumps--;
            if(IsGrounded())
            {
                Jump();
                numberOfJumps = maxNumberOfJumps;
            }
            else if(numberOfJumps > 0)
            {
                Jump();
            }
        }
    }
}

