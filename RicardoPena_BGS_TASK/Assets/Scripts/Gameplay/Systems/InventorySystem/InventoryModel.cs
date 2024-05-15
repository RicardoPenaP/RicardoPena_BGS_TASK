using Gameplay.Items;
using Gameplay.Systems.InventorySystem.Common;
using System;
using UnityEngine;

namespace Gameplay.Systems.InventorySystem
{
    public class InventoryModel : MonoBehaviour
    {
        [Header("Inventory Model")]
        [Header("Settings")]
        [SerializeField] private int amountOfInventorySlots = 25;

        public event Action OnInventoryModelInitialized;
        public event Action<InventorySlot> OnInventorySlotUpdated;

        private InventorySlot[] inventorySlots;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            inventorySlots = new InventorySlot[amountOfInventorySlots];
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                inventorySlots[i] = new InventorySlot();
            }
            OnInventoryModelInitialized?.Invoke();
        }

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
            foreach (InventorySlot inventorySlot in inventorySlots)
            {
                if (inventorySlot.CurrentItem is null)
                {
                    continue;
                }

                if (inventorySlot.CurrentItem.ItemName.Equals(item.ItemName))
                {
                    if (inventorySlot.TryToStackItem(item, amount))
                    {
                        OnInventorySlotUpdated?.Invoke(inventorySlot);
                        return true;
                    }
                }
            }

            return false;
        }

        private bool TryToAddToNewSlot(Item item, int amount)
        {
            foreach (InventorySlot inventorySlot in inventorySlots)
            {
                if (inventorySlot.CurrentItem is not null)
                {
                    continue;
                }
                inventorySlot.SetCurrentItem(item, amount);
                OnInventorySlotUpdated?.Invoke(inventorySlot);
                return true;
            }
            return false;
        }

        public InventorySlot[] GetInventorySlots() => inventorySlots;

    }
}