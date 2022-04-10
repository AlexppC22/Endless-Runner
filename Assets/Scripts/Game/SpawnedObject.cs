using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class SpawnedObject : MonoBehaviour
    {
        public float speed;
        public Rigidbody2D objectRB;
        public AudioClip collisionSFX;

        protected void Awake() 
        {
            SetSpeed(GameManager.instance.upgradeManager.gameSpd);
        }
        protected void Update() 
        {
            if(!GameManager.instance.gameRunning)
                Destroy(this.gameObject);
        }
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                PlayerCollision();
                Destroy(this.gameObject);
            } 
            if(other.gameObject.CompareTag("ObjectDestroyer"))
                Destroy(this.gameObject);
        }

        public virtual void SetSpeed(float receivedSpeed)
        {
            this.speed += receivedSpeed;
            objectRB.velocity = new Vector2(-1 * this.speed, 0);
        }

        public virtual void PlayerCollision()
        {
            SFXManager.instance.PlaySFX(collisionSFX);
        }
    }
}

