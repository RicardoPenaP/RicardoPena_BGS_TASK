using Gameplay.Items;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Systems.ShopSystem.Common
{
    public class ShopSlotVisual : MonoBehaviour
    {
        public static event Action<ShopSlotVisual> OnAnyShopSlotVisualSelected;

        [Header("Shop Slot Visual")]
        [Header("References")]
        [SerializeField] private Image icon;
        [SerializeField] private Image frame;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI costText;

        private Item currentItem;

        public void SetSlotVisuals(ShopSlot shopSlot)
        {
            currentItem = shopSlot.CurrentItem;
            icon.sprite = currentItem.Icon;
            nameText.text = currentItem.ItemName;
            costText.text = $"{currentItem.GetBuyPrice()}";
        }

        public void SlotSelected()
        {
            OnAnyShopSlotVisualSelected?.Invoke(this);
        }
    }
}
