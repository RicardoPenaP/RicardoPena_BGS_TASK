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
        [SerializeField] private int maxGoldAmount = 100000000;

        public event Action OnInventoryModelInitialized;
        public event Action<InventorySlot, int> OnInventorySlotUpdated;
        public event Action<int> OnGoldAmountChanged;

        private InventorySlot[] inventorySlots;

        private int goldAmount;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            SetGoldAmount(0);
            inventorySlots = new InventorySlot[amountOfInventorySlots];
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                inventorySlots[i] = new InventorySlot();
            }
            OnInventoryModelInitialized?.Invoke();
        }

        public bool TryToAddItem(Item item, int amount = 1)
        {
            if (TryStackItem(item, amount))
            {
                return true;
            }

            if (TryToAddToNewSlot(item, amount))
            {
                return true;
            }

            return false;
        }

        private bool TryStackItem(Item item, int amount)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].CurrentItem is null)
                {
                    continue;
                }

                if (inventorySlots[i].CurrentItem.ItemName.Equals(item.ItemName))
                {
                    if (inventorySlots[i].TryToStackItem(item, amount))
                    {
                        OnInventorySlotUpdated?.Invoke(inventorySlots[i], i);
                        return true;
                    }
                }
            }

            return false;
        }

        private bool TryToAddToNewSlot(Item item, int amount)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].CurrentItem is not null)
                {
                    continue;
                }
                inventorySlots[i].SetCurrentItem(item, amount);
                OnInventorySlotUpdated?.Invoke(inventorySlots[i], i);
                return true;
            }            
            return false;
        }

        public InventorySlot[] GetInventorySlots() => inventorySlots;

        public void AddGold(int amount)
        {
            SetGoldAmount(goldAmount + Mathf.Abs(amount));
        }

        public bool TryToGetGold(int amount)
        {
            if (Mathf.Abs(amount) > goldAmount)
            {
                return false;
            }
            SetGoldAmount(goldAmount - Mathf.Abs(amount));
            return true;
        }

        public bool HaveEnoughGold(int amount)
        {
            return Mathf.Abs(amount) <= goldAmount;
        }

        public int GetGoldAmount() => goldAmount;

        private void SetGoldAmount(int value)
        {
            goldAmount = Mathf.Clamp(value, 0, maxGoldAmount);
            OnGoldAmountChanged?.Invoke(goldAmount);
        }

        public void SellItem(Item selectedItem)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].CurrentItem is null)
                {
                    continue;
                }
                if (inventorySlots[i].CurrentItem.Equals(selectedItem))
                {
                    AddGold(inventorySlots[i].CurrentItem.GetSellPrice() * inventorySlots[i].ItemAmount);

                }
                inventorySlots[i].SetCurrentItem(null);
                OnInventorySlotUpdated?.Invoke(inventorySlots[i], i);
            }
        }
    }
}