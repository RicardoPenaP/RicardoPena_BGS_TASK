﻿using UnityEngine;

namespace Gameplay.Items
{
    [CreateAssetMenu(fileName = "NewUnequipableItem", menuName = "Gameplay/Items/Unequipable Item")]
    public class UnequipableItem : Item
    {
        [SerializeField] private bool isStackable = false;
        [SerializeField] private int maxStackAmount = 100;
    }
}