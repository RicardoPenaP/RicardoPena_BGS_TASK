using System;
using UnityEngine;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public interface IInteractorModel
    {
        public event Action<IInteractable> OnCurrentInteractableEntityChange;
        public event Action OnInteractionStarted;
        public event Action<float> OnInteractionInProgress;
        public event Action OnInteractionFinished;
        public void SetCurrentInteractableEntity(IInteractable interactableEntity);
        public Vector2 GetInteractuatorPosition();
        public void ToggleInteraction(bool state);
        
    }
}