using System;
using System.Collections.Generic;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public class InteractabilityController : IDisposable
    {
        private readonly IInteractabilityView interactabilityView;
        private readonly IInteractabilityModel interactabilityModel;

        public InteractabilityController(IInteractabilityView interactabilityView, IInteractabilityModel interactabilityModel)
        {
            this.interactabilityView = interactabilityView;
            this.interactabilityModel = interactabilityModel;
            Init();
        }

        public void Dispose()
        {
            Deinit();
        }

        private void Init()
        {
            interactabilityView.OnInteractInputUpdated += InteractabilityView_OnInteractInputUpdated;
            interactabilityView.OnInteractableEntitiesFound += InteractabilityView_OnInteractableEntitiesFound;
        }       

        private void Deinit()
        {
            interactabilityView.OnInteractInputUpdated -= InteractabilityView_OnInteractInputUpdated;
            interactabilityView.OnInteractableEntitiesFound -= InteractabilityView_OnInteractableEntitiesFound;
        }

        private void InteractabilityView_OnInteractInputUpdated(bool state)
        {
            
        }

        private void InteractabilityView_OnInteractableEntitiesFound(List<IInteractable> interactablesEntities)
        {
            
        }

    }
}
