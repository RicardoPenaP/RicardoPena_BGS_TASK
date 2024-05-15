using Gameplay.Items;
using UnityEngine;

namespace Gameplay.Systems.InventorySystem
{
    public class InventorySystem : MonoBehaviour
    {
        private static InventorySystem instance;
        private static InventorySystem Instance => instance;

        [Header("Inventory System")]
        [Header("References")]
        [SerializeField] private InventoryController inventoryController;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            if (instance is not null && !instance.Equals(this))
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public bool TryToAddItem(Item item, int amount = 1) => inventoryController.TryToAddItem(item, amount);
    }
}

