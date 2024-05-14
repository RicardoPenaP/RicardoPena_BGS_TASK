using UnityEngine;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public interface IInteractable
    {
        public void ShowInteractabilityFeedback();
        public void HideInteractabilityFeedback();
        public void Interact();
        public Vector2 GetInteractablePosition();
        public float GetInteractionTime();
    }
}