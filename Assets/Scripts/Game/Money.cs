using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Money : MonoBehaviour
    {
        public int value;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Dihneiro coletado");
                GameManager.instance.AddMoney(value);
                Destroy(this.gameObject);
            }    
        }
    }
}

