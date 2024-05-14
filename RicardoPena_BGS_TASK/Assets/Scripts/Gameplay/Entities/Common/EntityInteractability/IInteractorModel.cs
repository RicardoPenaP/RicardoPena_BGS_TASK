using System;
using UnityEngine;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public interface IInteractorModel
    {
        public event Action<IInteractable> OnCurrentInteractableEntityChange;
        public void SetCurrentInteractableEntity(IInteractable interactableEntity);
        public Vector2 GetInteractuatorPosition();
    }
}