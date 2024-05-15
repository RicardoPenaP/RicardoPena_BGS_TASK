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
        }

        private void Deinit()
        {
            shopView.OnCloseButtonPressed -= () => CloseShop();
        }

        public void OpenShop(IShopModel shopModel)
        {
            this.shopModel = shopModel;
            shopView.SetShopSlotsVisual(this.shopModel.GetShopSlots());
            shopView.ToggleShopView(true);
            this.shopModel.SetShopOpen(true);
            InventorySystem.InventorySystem.Instance.OpenInventory();
        }

        public void CloseShop()
        {
            shopView.ToggleShopView(false);
            shopModel.SetShopOpen(false);
            InventorySystem.InventorySystem.Instance.CloseInventory();
        }
    }
}