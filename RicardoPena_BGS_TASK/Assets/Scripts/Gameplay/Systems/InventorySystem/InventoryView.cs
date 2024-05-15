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

        private InventorySlotVisual[] inventorySlotVisuals;

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
            closeButton.onClick.AddListener(CloseButton_OnClick);
            sellButton.onClick.AddListener(SellButton_OnClick);
            equipButton.onClick.AddListener(EquipButton_OnClick);
        }

        private void Deinit()
        {
            closeButton.onClick.RemoveListener(CloseButton_OnClick);
            sellButton.onClick.RemoveListener(SellButton_OnClick);
            equipButton.onClick.RemoveListener(EquipButton_OnClick);
        }

        private void CloseButton_OnClick()
        {
            OnCloseButtonPressed?.Invoke();
        }

        private void SellButton_OnClick()
        {
            OnSellButtonPressed?.Invoke();
        }

        private void EquipButton_OnClick()
        {
            OnEquipButtonPressed?.Invoke();
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
            inventorySlotVisuals = new InventorySlotVisual[inventorySlots.Length];
            for (int i = 0; i < inventorySlotVisuals.Length; i++)
            {
                inventorySlotVisuals[i] = Instantiate(inventorySlotVisualPrefab, inventorySlotsGridLayout.position,
                                                      Quaternion.identity, inventorySlotsGridLayout);
                inventorySlotVisuals[i].SetSlotVisuals(inventorySlots[i]);
            }
        }
    }
}
