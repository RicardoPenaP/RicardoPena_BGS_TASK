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

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            throw new NotImplementedException();
        }

        public ShopSlot[] GetShopSlots()
        {
            throw new System.NotImplementedException();
        }
    }
}
