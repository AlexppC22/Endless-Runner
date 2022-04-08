using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class Item : MonoBehaviour
    {
        public int id;
        public int value;
        public string description;

        public HUBUI hubUI;

        public void SetItem()
        {
            hubUI.ToogleItemSelection(this);
        }
        public void SetUpgrade()
        {
            hubUI.ToggleUpgradeSelection(this);
        }
    }
}

