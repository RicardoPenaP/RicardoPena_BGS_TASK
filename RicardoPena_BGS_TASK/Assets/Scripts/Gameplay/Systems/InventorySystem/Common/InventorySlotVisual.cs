using Gameplay.Items;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Systems.InventorySystem.Common
{
    public class InventorySlotVisual : MonoBehaviour
    {
        public static event Action<InventorySlotVisual> OnAnySlotVisualSelected;

        [Header("Inventory Slot")]
        [Header("References")]
        [SerializeField] private Image icon;
        [SerializeField] private Image frame;
        [SerializeField] private TextMeshProUGUI stackText;
        [SerializeField] private Image equipedIcon;

        private int itemAmount;
        private Item currentItem;

        public void SetSlotVisuals(InventorySlot inventorySlot)
        {
            if (inventorySlot.CurrentItem is null)
            {
                itemAmount = 0;
                currentItem = null;
                icon.gameObject.SetActive(false);
                frame.gameObject.SetActive(false);
                stackText.gameObject.SetActive(false);
                return;
            }

            currentItem = inventorySlot.CurrentItem;
            itemAmount = inventorySlot.ItemAmount;
            SetStackText();
            icon.sprite = inventorySlot.CurrentItem.Icon;
            icon.gameObject.SetActive(true);
        }

        private void SetStackText()
        {
            if (currentItem is not IStackable)
            {
                stackText.gameObject.SetActive(false);
            }
            else
            {
                stackText.text = $"{itemAmount}";
                if (!stackText.gameObject.activeInHierarchy)
                {
                    stackText.gameObject.SetActive(true);
                }
            }
        }

        public Item GetCurrentItem() => currentItem;

        public int GetItemAmount() => itemAmount;

        public void ToggleFrame(bool state)
        {
            frame.gameObject.SetActive(state);
        }
        
        public void SlotVisualPressed()
        {
            OnAnySlotVisualSelected?.Invoke(this);
        }

        public void ToggleEquipedIcon(bool state)
        {
            equipedIcon.gameObject.SetActive(state);
        }
    }
}
