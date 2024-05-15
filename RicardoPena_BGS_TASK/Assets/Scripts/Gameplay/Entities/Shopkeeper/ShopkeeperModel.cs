using Gameplay.Items;
using Gameplay.Systems.ShopSystem;
using Gameplay.Systems.ShopSystem.Common;
using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class ShopkeeperModel : MonoBehaviour, IShopModel
    {
        [Header("Shop Model")]
        [Header("References")]
        [SerializeField] private Item[] sellableItems;

        [Header("Settings")]
        [SerializeField] private float interactionCooldown = 0.2f;

        private ShopSlot[] shopSlots;

        private bool canInteract = true;
        private bool shopOpen = false;

        public bool CanInteract => canInteract;
        public bool ShopOpen => shopOpen;

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

        public void StartInteraction()
        {
            if (!canInteract)
            {
                return;
            }            
            StartCoroutine(InteractionCooldownRoutine());
        }

        private IEnumerator InteractionCooldownRoutine()
        {
            canInteract = false;
            float timer = 0f;
            while (timer < interactionCooldown)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            canInteract = true;
        }

        public void SetShopOpen(bool state)
        {
            shopOpen = state;
        }
    }
}
