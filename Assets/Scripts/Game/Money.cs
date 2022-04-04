using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Money : MonoBehaviour
    {
        public int value;
        public Rigidbody2D moneyRB;
        public float speed;
        private void Update() 
        {
            moneyRB.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
            if(!GameManager.instance.gameRunning)
                Destroy(this.gameObject);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Dihneiro coletado");
                GameManager.instance.AddMoney(value);
                Destroy(this.gameObject);
            } 
            if(other.gameObject.CompareTag("ObjectDestroyer"))
                Destroy(this.gameObject);   
        }
    }
}

