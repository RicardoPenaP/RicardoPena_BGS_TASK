using Gameplay.Entities.Common.EntityInteractability;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class Shopkeeper : MonoBehaviour, IInteractable
    {
        [Header("Shopkeeper")]
        [Header("References")]
        [SerializeField] private ShopkeeperController shopkeeperController;

        [Header("Settings")]
        [SerializeField] private InteractableSettings settings;

        public void ShowInteractabilityFeedback()
        {
            shopkeeperController.ToggleInteractionText(true);
        }

        public void HideInteractabilityFeedback()
        {
            shopkeeperController.ToggleInteractionText(false);            
        }

        public void Interact()
        {
            shopkeeperController.OpenShop();
        }

        public Vector2 GetInteractablePosition()
        {
            return transform.position;
        }

        public float GetInteractionTime()
        {
            return settings.InteractionTime;
        }
    }
}
