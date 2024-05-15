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

        public void SetCurrentItem(Item item, int itemAmount = 1)
        {
            currentItem = item;
            this.itemAmount = itemAmount;
            ProcessItem();
        }

        private void ProcessItem()
        {
            if (currentItem is null)
            {
                itemAmount = 0;
            }

            if (currentItem is IStackable)
            {
                SetStackText();
            }
        }

        private void SetStackText()
        {

        }
    }
}
