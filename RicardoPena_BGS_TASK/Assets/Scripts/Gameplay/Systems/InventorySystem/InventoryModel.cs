using Gameplay.Items;
using Gameplay.Systems.InventorySystem.Common;
using UnityEngine;

namespace Gameplay.Systems.InventorySystem
{
    public class InventoryModel : MonoBehaviour
    {
        [Header("Inventory Model")]
        [Header("References")]
        [SerializeField] private InventorySlot[] invetorySlots;

        public bool TryToAddItem(Item item, int amount = 1)
        {
            if (TryStackItem(item,amount))
            {
                return true;
            }

            if (TryToAddToNewSlot(item,amount))
            {
                return true;
            }

            return false;
        }

        private bool TryStackItem(Item item, int amount)
        {
            foreach (InventorySlot inventorySlot in invetorySlots)
            {
                if (inventorySlot.CurrentItem.ItemName.Equals(item.ItemName))
                {
                    if (inventorySlot.TryToStackItem(item, amount))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool TryToAddToNewSlot(Item item, int amount)
        {
            foreach (InventorySlot inventorySlot in invetorySlots)
            {
                if (inventorySlot.CurrentItem is not null)
                {
                    continue;
                }
                inventorySlot.SetCurrentItem(item, amount);
                return true;
            }
            return false;
        }
        
    }
}