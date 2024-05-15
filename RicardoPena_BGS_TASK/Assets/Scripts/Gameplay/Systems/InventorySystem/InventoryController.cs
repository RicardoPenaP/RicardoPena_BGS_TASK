using Gameplay.Items;
using Gameplay.Systems.InventorySystem.Common;
using System;
using UnityEngine;

namespace Gameplay.Systems.InventorySystem
{
    public class InventoryController : MonoBehaviour
    {
        [Header("Inventory Controller")]
        [Header("References")]
        [SerializeField] private InventoryView inventoryView;
        [SerializeField] private InventoryModel inventoryModel;

        private void Awake()
        {
            Init();
        }

        private void OnDestroy()
        {
            Deinit();
        }

        private void Init()
        {
            inventoryView.OnSellButtonPressed += InventoryView_OnSellButtonPressed;

            inventoryModel.OnInventoryModelInitialized += InventoryModel_OnInventoryModelInitialized;
            inventoryModel.OnInventorySlotUpdated += InventoryModel_OnInventorySlotUpdated;
            inventoryModel.OnGoldAmountChanged += InventoryModel_OnGoldAmountChanged;
        }


        private void Deinit()
        {
            inventoryView.OnSellButtonPressed -= InventoryView_OnSellButtonPressed;

            inventoryModel.OnInventoryModelInitialized -= InventoryModel_OnInventoryModelInitialized;
            inventoryModel.OnInventorySlotUpdated -= InventoryModel_OnInventorySlotUpdated;
            inventoryModel.OnGoldAmountChanged -= InventoryModel_OnGoldAmountChanged;
        }

        private void InventoryView_OnSellButtonPressed(Item selectedItem)
        {
            inventoryModel.SellItem(selectedItem);
        }

        private void InventoryModel_OnInventoryModelInitialized()
        {
            inventoryView.SetInvetorySlotsVisual(inventoryModel.GetInventorySlots());
        }

        private void InventoryModel_OnInventorySlotUpdated(InventorySlot inventorySlot, int index)
        {
            inventoryView.UpdateInventoySlotVisual(inventorySlot, index);
        }

        private void InventoryModel_OnGoldAmountChanged(int goldAmount)
        {
            inventoryView.UpdateGoldText(goldAmount);
        }

        public bool TryToAddItem(Item item, int amount = 1) => inventoryModel.TryToAddItem(item, amount);

        public void ToggleInventory() => inventoryView.ToggleInventoryView(!inventoryView.gameObject.activeInHierarchy);

        public void AddGold(int amount) => inventoryModel.AddGold(amount);
        
    }
}

