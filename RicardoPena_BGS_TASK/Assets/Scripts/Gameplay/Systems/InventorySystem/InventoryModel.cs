using Gameplay.Systems.InventorySystem.Common;
using UnityEngine;

namespace Gameplay.Systems.InventorySystem
{
    public class InventoryModel : MonoBehaviour
    {
        [Header("Inventory Model")]
        [Header("References")]
        [SerializeField] private InventorySlot[] invetorySlots;
    }
}