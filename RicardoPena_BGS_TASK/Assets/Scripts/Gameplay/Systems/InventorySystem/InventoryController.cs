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
            inventoryModel.OnInventoryModelInitialized += InventoryModel_OnInventoryModelInitialized;
            inventoryModel.OnInventorySlotUpdated += InventoryModel_OnInventorySlotUpdated;
        }

        private void Deinit()
        {
            inventoryModel.OnInventoryModelInitialized -= InventoryModel_OnInventoryModelInitialized;
            inventoryModel.OnInventorySlotUpdated -= InventoryModel_OnInventorySlotUpdated;
        }

        private void InventoryModel_OnInventoryModelInitialized()
        {
            inventoryView.SetInvetorySlotsVisual(inventoryModel.GetInventorySlots());
        }

        private void InventoryModel_OnInventorySlotUpdated(InventorySlot inventorySlot, int index)
        {
            inventoryView.UpdateInventoySlotVisual(inventorySlot, index);
        }

        public bool TryToAddItem(Item item, int amount = 1) => inventoryModel.TryToAddItem(item, amount);
    }
}

