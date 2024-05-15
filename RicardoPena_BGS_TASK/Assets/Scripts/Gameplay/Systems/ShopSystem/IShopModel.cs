﻿using Gameplay.Systems.ShopSystem.Common;

namespace Gameplay.Systems.ShopSystem
{
    public interface IShopModel 
    {
        public ShopSlot[] GetShopSlots();
    }
}