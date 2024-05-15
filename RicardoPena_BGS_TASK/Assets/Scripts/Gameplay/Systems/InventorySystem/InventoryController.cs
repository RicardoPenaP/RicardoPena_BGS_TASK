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
            inventoryView.OnEquipButtonPressed += InventoryView_OnEquipButtonPressed;

            inventoryModel.OnInventoryModelInitialized += InventoryModel_OnInventoryModelInitialized;
            inventoryModel.OnInventorySlotUpdated += InventoryModel_OnInventorySlotUpdated;
            inventoryModel.OnGoldAmountChanged += InventoryModel_OnGoldAmountChanged;
            inventoryModel.OnCanSellChanged += InventoryModel_OnCanSellChanged;
            inventoryModel.OnEquipedItemChanged += InventoryModel_OnEquipedItemChanged;

        }

        private void Deinit()
        {
            inventoryView.OnSellButtonPressed -= InventoryView_OnSellButtonPressed;
            inventoryView.OnEquipButtonPressed -= InventoryView_OnEquipButtonPressed;

            inventoryModel.OnInventoryModelInitialized -= InventoryModel_OnInventoryModelInitialized;
            inventoryModel.OnInventorySlotUpdated -= InventoryModel_OnInventorySlotUpdated;
            inventoryModel.OnGoldAmountChanged -= InventoryModel_OnGoldAmountChanged;
            inventoryModel.OnCanSellChanged -= InventoryModel_OnCanSellChanged;
            inventoryModel.OnEquipedItemChanged -= InventoryModel_OnEquipedItemChanged;
        }

        private void InventoryView_OnSellButtonPressed(Item selectedItem, int? index)
        {
            inventoryModel.SellItem(selectedItem, (int)index);
        }

        private void InventoryView_OnEquipButtonPressed(Item selectedItem, int? index)
        {
            inventoryModel.EquipUnequipItem(selectedItem, (int)index);
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

        private void InventoryModel_OnCanSellChanged(bool state)
        {
            inventoryView.SetCanSell(state);
        }

        private void InventoryModel_OnEquipedItemChanged(Item equipedItem, int index)
        {
            inventoryView.SetEquipedItemIcon(equipedItem, index);
        }


        public bool TryToAddItem(Item item, int amount = 1) => inventoryModel.TryToAddItem(item, amount);

        public void ToggleInventory() => inventoryView.ToggleInventoryView(!inventoryView.gameObject.activeInHierarchy);

        public void OpenInventory() => inventoryView.ToggleInventoryView(true);

        public void CloseInventory() => inventoryView.ToggleInventoryView(false);

        public void AddGold(int amount) => inventoryModel.AddGold(amount);

        public int GetCurrentGold() => inventoryModel.GetGoldAmount();

        public void SetCanSell(bool state) => inventoryModel.SetCanSell(state);

        public bool TryToGetGold(int amount) => inventoryModel.TryToGetGold(amount);
    }
}

