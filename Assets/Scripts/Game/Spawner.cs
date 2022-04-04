using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Spawner : MonoBehaviour
    {
        public GameObject spawnedObject;
        public float spawnDelay;
        float timer;

        private void Update() 
        {
            if(!GameManager.instance.gameRunning) {return;}

            if(timer > spawnDelay)
                Spawn();
            else
                timer += Time.deltaTime;        
        }

        public void Spawn()
        {
            Instantiate(spawnedObject, this.transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}

