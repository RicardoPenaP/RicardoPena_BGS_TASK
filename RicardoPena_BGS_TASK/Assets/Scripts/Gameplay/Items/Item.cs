using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Items
{    
    public abstract class Item : ScriptableObject
    {
        [Header("Item")]
        [SerializeField] protected string itemName;
        [SerializeField] protected Image icon;

        public string ItemName => itemName;
        public Image Icon => icon;
    }
}