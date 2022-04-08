using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory Manager")]
    public class InventoryManager : ScriptableObject
    {
        public int item0Quantity;
        public int item1Quantity;
        public int item2Quantity;
        public int item3Quantity;
    }
}

