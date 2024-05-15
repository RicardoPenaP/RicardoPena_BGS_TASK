using Gameplay.Systems.ShopSystem;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class ShopkeeperController : MonoBehaviour
    {
        [Header("Shopkeeper Controller")]
        [Header("References")]
        [SerializeField] private ShopkeeperView shopkeeperView;
        [SerializeField] private ShopkeeperModel shopkeeperModel;

        public void ToggleInteractionText(bool state) => shopkeeperView.ToggleInteractionText(state);

        public void OpenShop()
        {
            if (shopkeeperModel.CanInteract && !shopkeeperModel.ShopOpen)
            {
                shopkeeperModel.StartInteraction();
                ShopSystem.Instance.OpenShop(shopkeeperModel);
                shopkeeperModel.SetShopOpen(true);
            }
        }

        public void CloseShop()
        {
            if (shopkeeperModel.ShopOpen)
            {
                ShopSystem.Instance.CloseShop();
                shopkeeperModel.SetShopOpen(false);
            }
        }
    }
}
