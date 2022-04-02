using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Obstacle : MonoBehaviour
    {
        public int damage;
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

