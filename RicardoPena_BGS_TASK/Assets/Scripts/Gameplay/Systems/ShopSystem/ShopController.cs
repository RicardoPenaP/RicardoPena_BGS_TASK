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
        }
    }
}