using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Obstacle : MonoBehaviour
    {
        public int damage;
        public float speed;
        public Rigidbody2D obstacleRB;

        private void Update() 
        {
            obstacleRB.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
            if(!GameManager.instance.gameRunning)
                Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Colidiu com obstaculo");
                GameManager.instance.TakeDamage(damage);
                Destroy(this.gameObject);
            }    
        }
    }
}

