﻿using UnityEngine;

namespace Gameplay.Items
{
    public abstract class Item : ScriptableObject, ISellable
    {
        [Header("Item")]
        [SerializeField] protected string itemName;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected int sellPrice;
        [SerializeField] protected int buyPrice;

        public string ItemName => itemName;
        public Sprite Icon => icon;

        public int GetSellPrice() => sellPrice;

        public void Sell()
        {
            throw new System.NotImplementedException();
        }
    }
}