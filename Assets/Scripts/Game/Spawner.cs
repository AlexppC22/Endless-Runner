using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Spawner : MonoBehaviour
    {
        public GameObject spawnedObject;
        public float spawnDelay;
        public float spawnDelayMin;
        public float spawnDelayMax;
        float timer;

        private void Update() 
        {
            if(!GameManager.instance.gameRunning) {return;}

            if(timer > spawnDelay)
                Spawn();
            else
            {
                float newSpawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
                spawnDelay = newSpawnDelay;
                timer += Time.deltaTime;
            }
                       
        }

        public void Spawn()
        {
            GameObject newObject = Instantiate(spawnedObject, this.transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}

