using Gameplay.Items;
using System;
using UnityEngine;

namespace Gameplay.Systems.ShopSystem
{
    public class ShopController : MonoBehaviour
    {
        [Header("Shop Controller")]
        [Header("References")]
        [SerializeField] private ShopView shopView;

        private IShopModel shopModel;

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
            shopView.OnCloseButtonPressed += () => CloseShop();
            shopView.OnBuyButtonPressed += ShopView_OnBuyButtonPressed;
        }


        private void Deinit()
        {
            shopView.OnCloseButtonPressed -= () => CloseShop();
            shopView.OnBuyButtonPressed -= ShopView_OnBuyButtonPressed;
        }

        private void ShopView_OnBuyButtonPressed(Item selectedItem)
        {
            if (InventorySystem.InventorySystem.Instance.TryToAddItem(selectedItem))
            {
                //InventorySystem.InventorySystem.Instance.try
            }
        }

        public void OpenShop(IShopModel shopModel)
        {
            this.shopModel = shopModel;
            shopView.SetShopSlotsVisual(this.shopModel.GetShopSlots());
            shopView.ToggleShopView(true);
            this.shopModel.SetShopOpen(true);

            InventorySystem.InventorySystem.Instance.SetCanSell(true);
            InventorySystem.InventorySystem.Instance.OpenInventory();

        }

        public void CloseShop()
        {
            shopView.ToggleShopView(false);
            shopModel.SetShopOpen(false);
            InventorySystem.InventorySystem.Instance.SetCanSell(false);
            InventorySystem.InventorySystem.Instance.CloseInventory();
        }
    }
}