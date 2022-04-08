using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    [CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/Upgrade Manager")]
    public class UpgradeManager : ScriptableObject
    {
        public int playerLife;
        public int gameSpd;
        public int playerJumps;
    }
}

