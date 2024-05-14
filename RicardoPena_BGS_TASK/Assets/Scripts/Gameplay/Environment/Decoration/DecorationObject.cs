using Gameplay.Entities.Common.EntityInteractability;
using UnityEngine;

namespace Gameplay.Environment.Decoration
{
    public class DecorationObject : MonoBehaviour, IInteractable
    {
        private DecorationObjectController decorationObjectController;
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            decorationObjectController = GetComponentInChildren<DecorationObjectController>();
        }

        public Vector2 GetInteractablePosition()
        {
            return transform.position;
        }

        public void HideInteractabilityFeedback()
        {
            decorationObjectController.ToogleInteractionText(false);
        }

        public void ShowInteractabilityFeedback()
        {
            decorationObjectController.ToogleInteractionText(true);
        }

        public void Interact()
        {
            //Testing
            //Destroy(gameObject);
            Debug.Log("Interacted with decoration object");
        }

        public float GetInteractionTime()
        {
            return 3f;
        }
    }
}
