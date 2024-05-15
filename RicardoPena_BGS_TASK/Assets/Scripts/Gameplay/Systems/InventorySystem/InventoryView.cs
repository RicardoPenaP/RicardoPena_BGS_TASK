using Gameplay.Items;
using Gameplay.Systems.InventorySystem.Common;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Systems.InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        [Header("Inventory View")]
        [Header("References")]
        [SerializeField] private Button closeButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private Button equipButton;
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private InventorySlotVisual inventorySlotVisualPrefab;
        [SerializeField] private Transform inventorySlotsGridLayout;

        public event Action OnCloseButtonPressed;
        public event Action OnSellButtonPressed;
        public event Action OnEquipButtonPressed;

        private InventorySlotVisual[] inventorySlotsVisual;

        private InventorySlotVisual selectedInventorySlotVisual;

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
            InventorySlotVisual.OnAnySlotVisualSelected += InventorySlotVisual_OnAnySlotVisualSelected;
            closeButton.onClick.AddListener(CloseButton_OnClick);
            sellButton.onClick.AddListener(SellButton_OnClick);
            equipButton.onClick.AddListener(EquipButton_OnClick);            
        }

        private void Deinit()
        {
            InventorySlotVisual.OnAnySlotVisualSelected -= InventorySlotVisual_OnAnySlotVisualSelected;
            closeButton.onClick.RemoveListener(CloseButton_OnClick);
            sellButton.onClick.RemoveListener(SellButton_OnClick);
            equipButton.onClick.RemoveListener(EquipButton_OnClick);
        }

        private void InventorySlotVisual_OnAnySlotVisualSelected(InventorySlotVisual selectedInventorySlotVisual)
        {
            SetSelectedInventorySlotVisual(selectedInventorySlotVisual);
        }

        private void CloseButton_OnClick()
        {
            OnCloseButtonPressed?.Invoke();
            ToggleInventoryView(false);
        }

        private void SellButton_OnClick()
        {
            OnSellButtonPressed?.Invoke();
        }

        private void EquipButton_OnClick()
        {
            OnEquipButtonPressed?.Invoke();
        }

        public void ToggleInventoryView(bool state)
        {
            if (!state)
            {
                SetSelectedInventorySlotVisual(null);
            }
            gameObject.SetActive(state);
        }

        public void ToggleSellButton(bool state)
        {
            sellButton.gameObject.SetActive(state);
        }

        public void ToggleEquipButton(bool state)
        {
            equipButton.gameObject.SetActive(state);
        }

        public void SetInvetorySlotsVisual(InventorySlot[] inventorySlots)
        {
            inventorySlotsVisual = new InventorySlotVisual[inventorySlots.Length];
            for (int i = 0; i < inventorySlotsVisual.Length; i++)
            {
                inventorySlotsVisual[i] = Instantiate(inventorySlotVisualPrefab, inventorySlotsGridLayout.position,
                                                      Quaternion.identity, inventorySlotsGridLayout);
                inventorySlotsVisual[i].SetSlotVisuals(inventorySlots[i]);
            }
        }        

        public void UpdateInventoySlotVisual(InventorySlot inventorySlot, int index)
        {
            inventorySlotsVisual[index].SetSlotVisuals(inventorySlot);            
        }

        private void SetSelectedInventorySlotVisual(InventorySlotVisual slotVisual)
        {
            selectedInventorySlotVisual?.ToggleFrame(false);
            selectedInventorySlotVisual = slotVisual;
            selectedInventorySlotVisual?.ToggleFrame(true);

            HandleSellVisuals();
        }

        private void HandleSellVisuals()
        {
            if (selectedInventorySlotVisual is null)
            {
                ToggleSellButton(false);
                return;
            }

            if (selectedInventorySlotVisual.GetCurrentItem() is null)
            {
                ToggleSellButton(false);
                return;
            }

            
            ToggleSellButton(selectedInventorySlotVisual.GetCurrentItem() is ISellable);
        }
        
    }
}
