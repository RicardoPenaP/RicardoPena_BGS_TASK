using System;
using System.Collections.Generic;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public interface IInteractabilityView 
    {
        public event Action<bool> OnInteractInputUpdated;
        public event Action<List<IInteractable>> OnInteractableEntitiesFound;

    }
}