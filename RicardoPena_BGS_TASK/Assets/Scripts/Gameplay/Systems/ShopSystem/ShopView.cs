using Gameplay.Items;
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
        [SerializeField] private Button buyButton;

        public event Action OnCloseButtonPressed;
        public event Action<Item> OnBuyButtonPressed;

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
            buyButton.onClick.AddListener(BuyButtonPressed);
        }

        private void Deinit()
        {
            ShopSlotVisual.OnAnyShopSlotVisualSelected += ShopSlotVisual_OnAnyShopSlotVisualSelected;
            closeButton.onClick.RemoveListener(CloseButtonPressed);
            buyButton.onClick.RemoveListener(BuyButtonPressed);
        }

        private void ShopSlotVisual_OnAnyShopSlotVisualSelected(ShopSlotVisual selectedShopSlotVisual)
        {
            SetSelectedShopSlotVisual(selectedShopSlotVisual);
        }

        private void CloseButtonPressed()
        {            
            OnCloseButtonPressed?.Invoke();
        }

        private void BuyButtonPressed()
        {
            OnBuyButtonPressed?.Invoke(selectedShopSlotVisual.CurrentItem);
        }

        public void SetShopSlotsVisual(ShopSlot[] shopSlots)
        {
            selectedShopSlotVisual = null;
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
            HandleBuyVisuals();
        }

        private void HandleBuyVisuals()
        {
            if (selectedShopSlotVisual is null)
            {
                ToggleBuyButton(false);
                return;
            }

            if (selectedShopSlotVisual.CurrentItem is null)
            {
                ToggleBuyButton(false);
                return;
            }

            if (selectedShopSlotVisual.CurrentItem.GetBuyPrice() > InventorySystem.InventorySystem.Instance.GetCurrentGold())
            {
                ToggleBuyButton(false);
                return;
            }

            ToggleBuyButton(true);
        }

        private void ToggleBuyButton(bool state)
        {
            buyButton.gameObject.SetActive(state);
        }
    }
}