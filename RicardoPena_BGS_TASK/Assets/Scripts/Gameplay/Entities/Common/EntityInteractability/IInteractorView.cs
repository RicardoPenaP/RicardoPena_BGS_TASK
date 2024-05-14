using System;
using System.Collections.Generic;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public interface IInteractorView 
    {
        public event Action<bool> OnInteractInputUpdated;
        public event Action<List<IInteractable>> OnInteractableEntitiesFound;

    }
}