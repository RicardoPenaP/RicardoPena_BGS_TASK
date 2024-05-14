using System;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public interface IInteractabilityModel
    {
        public event Action<IInteractable> OnCurrentInteractableEntityChange;
        public void SetCurrentInteractableEntity(IInteractable interactableEntity);
    }
}