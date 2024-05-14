using TMPro;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class ShopkeeperView : MonoBehaviour
    {
        [Header("Shopkeeper View")]
        [Header("References")]
        [SerializeField] private TextMeshProUGUI interactionText;

        private void Awake()
        {
            ToggleInteractionText(false);
        }

        public void ToggleInteractionText(bool state)
        {
            interactionText.gameObject.SetActive(state);
        }
    }
}
