using UnityEngine;

namespace Gameplay.Systems.InventorySystem
{
    public class InventoryController : MonoBehaviour
    {
        [Header("Inventory Controller")]
        [Header("References")]
        [SerializeField] private InventoryView inventoryView;
        [SerializeField] private InventoryModel inventoryModel;
    }
}

