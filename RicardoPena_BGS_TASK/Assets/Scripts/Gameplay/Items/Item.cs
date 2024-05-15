using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Items
{    
    public abstract class Item : ScriptableObject
    {
        [Header("Item")]
        [SerializeField] protected string itemName;
        [SerializeField] protected Image icon;
        [SerializeField] protected int sellGoldValue;
        [SerializeField] protected int buyGoldValue;

        public string ItemName => itemName;
        public Image Icon => icon;
    }
}