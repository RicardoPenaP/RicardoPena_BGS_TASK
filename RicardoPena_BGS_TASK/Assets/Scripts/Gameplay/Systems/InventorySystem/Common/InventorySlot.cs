using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Systems.InventorySystem.Common
{
    public class InventorySlot : MonoBehaviour
    {
        [Header("Inventory Slot")]
        [Header("References")]
        [SerializeField] private Image icon;
        [SerializeField] private Image frame;
        [SerializeField] private TextMeshProUGUI stackText;

    }
}
