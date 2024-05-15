using UnityEngine;

namespace Gameplay.Items
{
    [CreateAssetMenu(fileName = "NewEquipableItem", menuName = "Gameplay/Items/Equipable Item")]
    public class EquipableItem : Item, IEquipable
    {
        [SerializeField] private ItemPart[] itemParts;

        public ItemPart[] ItemParts => itemParts;
    }
}