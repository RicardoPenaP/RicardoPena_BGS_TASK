using Gameplay.Items;
using Gameplay.Systems.ShopSystem;
using Gameplay.Systems.ShopSystem.Common;
using System;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class ShopkeeperModel : MonoBehaviour, IShopModel
    {
        [Header("Shop Model")]
        [Header("References")]
        [SerializeField] private Item[] sellableItems;

        private ShopSlot[] shopSlots;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            shopSlots = new ShopSlot[sellableItems.Length];
            for (int i = 0; i < shopSlots.Length; i++)
            {
                shopSlots[i] = new ShopSlot();
                shopSlots[i].SetCurrentItem(sellableItems[i]);
            }
        }

        public ShopSlot[] GetShopSlots()
        {
            return shopSlots;
        }
    }
}
