using Gameplay.Systems.ShopSystem.Common;
using UnityEngine;

namespace Gameplay.Systems.ShopSystem
{
    public class ShopView : MonoBehaviour
    {
        [Header("Shop View")]
        [Header("References")]
        [SerializeField] private ShopSlotVisual shopSlotVisualPrefab;
        [SerializeField] private Transform slotLayout;
    }
}