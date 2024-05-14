using System;
using System.Collections.Generic;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public interface IInteractorView 
    {
        public event Action<bool> OnInteractInputUpdated;
        public event Action<List<IInteractable>> OnInteractableEntitiesFound;
        public void ShowInteractionProgressBar();
        public void HideInteractionProgressBar();
        public void UpdateInteractionProgressBar(float normalizedValue);
    }
}