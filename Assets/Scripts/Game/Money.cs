using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Money : SpawnedObject
    {
        public int value;
        public override void PlayerCollision()
        {   
            GameManager.instance.AddMoney(value);
        }
    }
}

