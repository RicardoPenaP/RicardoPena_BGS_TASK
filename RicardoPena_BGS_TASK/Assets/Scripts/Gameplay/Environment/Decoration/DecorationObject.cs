using Gameplay.Entities.Common.EntityInteractability;
using Gameplay.Systems.InventorySystem;
using UnityEngine;

namespace Gameplay.Environment.Decoration
{
    public class DecorationObject : MonoBehaviour, IInteractable
    {
        [Header("Decoration Object")]
        [Header("References")]
        [SerializeField] private DecorationObjectController decorationObjectController;

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
            if (InventorySystem.Instance.TryToAddItem(decorationObjectController.GetInteractionReward(), decorationObjectController.GetRewardAmount()))
            {
                Debug.Log("Interacted with decoration object");
                gameObject.SetActive(false);
            }
        }

        public Vector2 GetInteractablePosition()
        {
            return transform.position;
        }

        public float GetInteractionTime()
        {
            return decorationObjectController.GetSettings().InteractionTime;
        }

    }
}
