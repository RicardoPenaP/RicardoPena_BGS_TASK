using Gameplay.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Systems.InventorySystem.Common
{
    public class InventorySlotVisual : MonoBehaviour
    {
        [Header("Inventory Slot")]
        [Header("References")]
        [SerializeField] private Image icon;
        [SerializeField] private Image frame;
        [SerializeField] private TextMeshProUGUI stackText;

        private int itemAmount;
        private Item currentItem;

        public void SetSlotVisuals(InventorySlot inventorySlot)
        {
            if (inventorySlot is null)
            {
                itemAmount = 0;
                currentItem = null;
                icon.gameObject.SetActive(false);
                frame.gameObject.SetActive(false);
                stackText.gameObject.SetActive(false);
                return;
            }

            currentItem = inventorySlot.CurrentItem;
            SetStackText();
            icon.sprite = inventorySlot.CurrentItem.Icon;
            icon.gameObject.SetActive(true);
        }

        private void SetStackText()
        {
            stackText.text = $"{itemAmount}";
            if (!stackText.gameObject.activeInHierarchy)
            {
                stackText.gameObject.SetActive(true);
            }
        }

        public Item GetCurrentItem() => currentItem;
    }
}
