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
            throw new System.NotImplementedException();
        }

        public void HideInteractabilityFeedback()
        {
            shopkeeperController.ToggleInteractionText(false);
        }

        public void Interact()
        {
            throw new System.NotImplementedException();
        }

        public void ShowInteractabilityFeedback()
        {
            shopkeeperController.ToggleInteractionText(true);
        }

    }
}
