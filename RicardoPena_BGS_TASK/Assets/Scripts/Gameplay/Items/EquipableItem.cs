using UnityEngine;

namespace Gameplay.Items
{
    [CreateAssetMenu(fileName = "NewEquipableItem", menuName = "Gameplay/Items/Equipable Item")]
    public class EquipableItem : Item, IEquipable
    {
        [SerializeField] private Sprite itemSprite;
    }
}