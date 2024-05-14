using System;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public interface IInteractabilityView 
    {
        public event Action<bool> OnInteractInputUpdated;
    }
}