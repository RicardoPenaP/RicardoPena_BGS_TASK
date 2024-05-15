using Gameplay.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Systems.InventorySystem.Common
{
    public class InventorySlot : MonoBehaviour
    {
        [Header("Inventory Slot")]
        [Header("References")]
        [SerializeField] private Image icon;
        [SerializeField] private Image frame;
        [SerializeField] private TextMeshProUGUI stackText;

        private Item currentItem;
        private int itemAmount;

        public Item CurrentItem => currentItem;

        public void SetCurrentItem(Item item, int itemAmount = 1)
        {
            currentItem = item;
            this.itemAmount = itemAmount;
            ProcessItem();
        }

        public bool TryToStackItem(Item item, int itemAmount)
        {
            if (currentItem is not IStackable)
            {
                return false;
            }

            if ((currentItem as IStackable).GetMaxStackAmount() < this.itemAmount + itemAmount)
            {
                return false;
            }

            this.itemAmount += itemAmount;
            SetStackText();
            return true;
        }               

        private void ProcessItem()
        {
            if (currentItem is null)
            {
                itemAmount = 0;
                icon.gameObject.SetActive(false);
                frame.gameObject.SetActive(false);
                stackText.gameObject.SetActive(false);
                return;
            }

            icon.sprite = currentItem.Icon;            

            if (currentItem is IStackable)
            {
                SetStackText();
            }
        }

        private void SetStackText()
        {
            stackText.text = $"{itemAmount}";
            if (!stackText.gameObject.activeInHierarchy)
            {
                stackText.gameObject.SetActive(true);
            }            
        }
    }
}
