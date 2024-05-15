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
        [SerializeField] private TextMeshProUGUI sellPriceText;
        [SerializeField] private GameObject sellPanel;
        [SerializeField] private InventorySlotVisual inventorySlotVisualPrefab;
        [SerializeField] private Transform inventorySlotsGridLayout;

        public event Action OnCloseButtonPressed;
        public event Action<Item, int?> OnSellButtonPressed;
        public event Action OnEquipButtonPressed;

        private InventorySlotVisual[] inventorySlotsVisual;

        private InventorySlotVisual selectedInventorySlotVisual;
        private int? selectedInventorySlotVisualIndex = 0;

        private bool canSell = false;

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
            OnSellButtonPressed?.Invoke(selectedInventorySlotVisual.GetCurrentItem(), selectedInventorySlotVisualIndex);
            SetSelectedInventorySlotVisual(null);
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

        private void ToggleSellPanel(bool state)
        {
            sellPanel.gameObject.SetActive(state);
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
            if (selectedInventorySlotVisual is not null)
            {
                if (inventorySlotsVisual[index].Equals(selectedInventorySlotVisual))
                {
                    HandleSellVisuals();
                }
            }
        }

        private void SetSelectedInventorySlotVisual(InventorySlotVisual slotVisual)
        {
            selectedInventorySlotVisual?.ToggleFrame(false);
            selectedInventorySlotVisual = slotVisual;
            selectedInventorySlotVisualIndex = selectedInventorySlotVisual?.transform.GetSiblingIndex();
            selectedInventorySlotVisual?.ToggleFrame(true);

            HandleSellVisuals();
            HandleEquipVisuals();
        }

        private void HandleSellVisuals()
        {
            if (!canSell)
            {
                ToggleSellPanel(false);
                return;
            }

            if (selectedInventorySlotVisual is null)
            {
                ToggleSellPanel(false);
                return;
            }

            if (selectedInventorySlotVisual.GetCurrentItem() is null)
            {
                ToggleSellPanel(false);
                return;
            }

            if (selectedInventorySlotVisual.GetCurrentItem() is not ISellable)
            {
                ToggleSellPanel(false);
                return;
            }

            int sellPrice = selectedInventorySlotVisual.GetCurrentItem().GetSellPrice() * selectedInventorySlotVisual.GetItemAmount();
            UpdateSellText(sellPrice);
            ToggleSellPanel(true);
        }

        public void UpdateGoldText(int amount)
        {
            goldText.text = $"{amount}";
        }

        public void UpdateSellText(int sellPrice)
        {
            sellPriceText.text = $"{sellPrice}";
        }

        public void SetCanSell(bool state) => canSell = state;

        private void HandleEquipVisuals()
        {
            if (selectedInventorySlotVisual is null)
            {
                ToggleEquipButton(false);
                return;
            }

            if (selectedInventorySlotVisual.GetCurrentItem() is null)
            {
                ToggleEquipButton(false);
                return;
            }

            if (selectedInventorySlotVisual.GetCurrentItem() is not IEquipable)
            {
                ToggleEquipButton(false);
                return;
            }

            ToggleEquipButton(true);
        }

    }
}
