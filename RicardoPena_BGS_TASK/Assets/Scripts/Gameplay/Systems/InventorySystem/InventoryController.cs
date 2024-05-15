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
        }       

        private void Deinit()
        {
            inventoryModel.OnInventoryModelInitialized -= InventoryModel_OnInventoryModelInitialized;
        }

        private void InventoryModel_OnInventoryModelInitialized()
        {
            inventoryView.SetInvetorySlotsVisual(inventoryModel.GetInventorySlots());
        }
    }
}

