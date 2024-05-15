using UnityEngine;

namespace Gameplay.Items
{
    [CreateAssetMenu(fileName = "NewUnequipableItem", menuName = "Gameplay/Items/Unequipable Item")]
    public class UnequipableItem : Item, IStackable
    {        
        [SerializeField] private int maxStackAmount = 100;

        public int GetMaxStackAmount()
        {
            return maxStackAmount;
        }
    }
}