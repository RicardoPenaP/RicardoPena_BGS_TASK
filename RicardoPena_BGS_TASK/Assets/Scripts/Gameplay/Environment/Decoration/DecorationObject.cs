using Gameplay.Entities.Common.EntityInteractability;
using UnityEngine;

namespace Gameplay.Environment.Decoration
{
    public class DecorationObject : MonoBehaviour, IInteractable
    {
        [Header("Decoration Object")]
        [Header("References")]
        [SerializeField] private DecorationObjectController decorationObjectController;

        [Header("Settings")]
        [SerializeField] private InteractableSettings settings;

        public void ShowInteractabilityFeedback()
        {
            decorationObjectController.ToggleInteractionText(true);
        }

        public void HideInteractabilityFeedback()
        {
            decorationObjectController.ToggleInteractionText(false);
        }

        public void Interact()
        {
            Debug.Log("Interacted with decoration object");
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
