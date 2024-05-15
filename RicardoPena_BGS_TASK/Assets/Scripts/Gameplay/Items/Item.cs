using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Items
{    
    public abstract class Item : ScriptableObject, ISellable
    {
        [Header("Item")]
        [SerializeField] protected string itemName;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected int sellGoldValue;
        [SerializeField] protected int buyGoldValue;

        public string ItemName => itemName;
        public Sprite Icon => icon;
    }
}