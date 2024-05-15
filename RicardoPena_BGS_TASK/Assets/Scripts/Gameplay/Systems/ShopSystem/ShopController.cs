using UnityEngine;

namespace Gameplay.Systems.ShopSystem
{
    public class ShopController : MonoBehaviour
    {
        [Header("Shop Controller")]
        [Header("References")]
        [SerializeField] private ShopView shopView;

        private IShopModel shopModel;

        public void OpenShop(IShopModel shopModel)
        {
            this.shopModel = shopModel;
            shopView.SetShopSlotsVisual(this.shopModel.GetShopSlots());
            shopView.ToggleShopView(true);
            InventorySystem.InventorySystem.Instance.OpenInventory();
        }

        public void CloseShop()
        {
            shopView.ToggleShopView(false);
            InventorySystem.InventorySystem.Instance.CloseInventory();
        }
    }
}