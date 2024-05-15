using Gameplay.Systems.ShopSystem.Common;
using UnityEngine;

namespace Gameplay.Systems.ShopSystem
{
    public class ShopView : MonoBehaviour
    {
        [Header("Shop View")]
        [Header("References")]
        [SerializeField] private ShopSlotVisual shopSlotVisualPrefab;
        [SerializeField] private Transform slotLayout;

        private ShopSlotVisual[] shopSlotsVisual;

        public void SetShopSlotsVisual(ShopSlot[] shopSlots)
        {
            shopSlotsVisual = new ShopSlotVisual[shopSlots.Length];
            for (int i = 0; i < shopSlotsVisual.Length; i++)
            {
                shopSlotsVisual[i] = Instantiate(shopSlotVisualPrefab, slotLayout.position, Quaternion.identity, slotLayout);
                shopSlotsVisual[i].SetSlotVisuals(shopSlots[i]);
            }
        }

        public void ToggleShopView(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}