using Gameplay.Systems.ShopSystem.Common;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Systems.ShopSystem
{
    public class ShopView : MonoBehaviour
    {
        [Header("Shop View")]
        [Header("References")]
        [SerializeField] private ShopSlotVisual shopSlotVisualPrefab;
        [SerializeField] private Transform slotLayout;
        [SerializeField] private Button closeButton;

        public event Action OnCloseButtonPressed;

        private ShopSlotVisual[] shopSlotsVisual;
        private ShopSlotVisual selectedShopSlotVisual;

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
            ShopSlotVisual.OnAnyShopSlotVisualSelected += ShopSlotVisual_OnAnyShopSlotVisualSelected;
            closeButton.onClick.AddListener(CloseButtonPressed);
        }

        private void Deinit()
        {
            ShopSlotVisual.OnAnyShopSlotVisualSelected += ShopSlotVisual_OnAnyShopSlotVisualSelected;
            closeButton.onClick.RemoveListener(CloseButtonPressed);
        }

        private void ShopSlotVisual_OnAnyShopSlotVisualSelected(ShopSlotVisual selectedShopSlotVisual)
        {
            SetSelectedShopSlotVisual(selectedShopSlotVisual);
        }

        private void CloseButtonPressed()
        {            
            OnCloseButtonPressed?.Invoke();
        }

        public void SetShopSlotsVisual(ShopSlot[] shopSlots)
        {
            if (shopSlotsVisual is not null)
            {                
                foreach (ShopSlotVisual shopSlotsVisual in shopSlotsVisual)
                {
                    Destroy(shopSlotsVisual.gameObject);
                }
            }            

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

        private void SetSelectedShopSlotVisual(ShopSlotVisual shopSlotVisual)
        {
            selectedShopSlotVisual?.ToggleFrame(false);
            selectedShopSlotVisual = shopSlotVisual;
            selectedShopSlotVisual?.ToggleFrame(true);
        }
    }
}