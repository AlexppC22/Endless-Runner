using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Obstacle : SpawnedObject
    {
        public int damage;

        public override void PlayerCollision()
        {   
            base.PlayerCollision();
            GameManager.instance.TakeDamage(damage);
        }
    }
}

