using Gameplay.Entities.Common.EntityInteractability;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class Shopkeeper : MonoBehaviour, IInteractable
    {
        [Header("Shopkeeper")]
        [Header("References")]
        [SerializeField] private ShopkeeperController shopkeeperController;

        public Vector2 GetInteractablePosition()
        {
            return transform.position;
        }

        public float GetInteractionTime()
        {
            return 0f;
        }

        public void HideInteractabilityFeedback()
        {
            shopkeeperController.ToggleInteractionText(false);
        }

        public void Interact()
        {
            Debug.Log("Interacted with shoopkeeper");
        }

        public void ShowInteractabilityFeedback()
        {
            shopkeeperController.ToggleInteractionText(true);
        }

    }
}
