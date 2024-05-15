using Gameplay.Items;
using UnityEngine;

namespace Gameplay.Systems.InventorySystem
{
    public class InventorySystem : MonoBehaviour
    {
        private static InventorySystem instance;
        public static InventorySystem Instance => instance;

        [Header("Shop System")]
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

        public void ToggleInventory() => inventoryController.ToggleInventory();

        public void OpenInventory() => inventoryController.OpenInventory();

        public void CloseInventory() => inventoryController.CloseInventory();

        public void AddGold(int amount) => inventoryController.AddGold(amount);

        public int GetCurrentGold() => inventoryController.GetCurrentGold();

        public void SetCanSell(bool state) => inventoryController.SetCanSell(state);

        public bool TryToGetGold(int amount) => inventoryController.TryToGetGold(amount);
    }
}

