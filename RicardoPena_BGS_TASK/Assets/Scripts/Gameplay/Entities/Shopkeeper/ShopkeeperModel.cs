using Gameplay.Systems.ShopSystem;
using Gameplay.Systems.ShopSystem.Common;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class ShopkeeperModel : MonoBehaviour, IShopModel
    {
        [Header("Shop Model")]
        [Header("References")]
        [SerializeField] private item
        public ShopSlot[] GetShopSlots()
        {
            throw new System.NotImplementedException();
        }
    }
}
