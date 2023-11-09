using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxthorne.FoxInventory
{
    public class SO_ItemData : ScriptableObject
    {
        public string itemName;
        public string itemId;
        public int maxStackSize = 100;
        public int weight = 1;
        public Sprite icon;
        public GameObject dropPrefab;
    }
}
