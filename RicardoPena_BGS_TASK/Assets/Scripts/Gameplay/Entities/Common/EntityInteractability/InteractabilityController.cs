using System;
using System.Collections.Generic;
using UnityEngine;

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
            if (interactablesEntities is null)
            {
                interactabilityModel.SetCurrentInteractableEntity(null);
                return;
            }

            Vector2 interactuatorPostion = interactabilityModel.GetInteractuatorPosition();
            IInteractable closestInteractableEntity = interactablesEntities[0];
            float closestDistance = Vector2.Distance(interactuatorPostion, closestInteractableEntity.GetInteractablePosition());

            foreach (IInteractable interactableEntity in interactablesEntities)
            {
                Vector2 interactableEntityPosition = interactableEntity.GetInteractablePosition();
                float newDistance = Vector2.Distance(interactuatorPostion, interactableEntityPosition);
                if (newDistance < closestDistance)
                {
                    closestInteractableEntity = interactableEntity;
                    closestDistance = newDistance;
                }
            }

            interactabilityModel.SetCurrentInteractableEntity(closestInteractableEntity);
        }

    }
}
