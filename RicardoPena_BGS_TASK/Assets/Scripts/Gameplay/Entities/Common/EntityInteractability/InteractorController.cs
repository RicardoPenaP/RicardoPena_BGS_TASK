using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Entities.Common.EntityInteractability
{
    public class InteractorController : IDisposable
    {
        private readonly IInteractorView interactorView;
        private readonly IInteractorModel interactorModel;

        public InteractorController(IInteractorView interactabilityView, IInteractorModel interactabilityModel)
        {
            this.interactorView = interactabilityView;
            this.interactorModel = interactabilityModel;
            Init();
        }

        public void Dispose()
        {
            Deinit();
        }

        private void Init()
        {
            interactorView.OnInteractInputUpdated += InteractabilityView_OnInteractInputUpdated;
            interactorView.OnInteractableEntitiesFound += InteractabilityView_OnInteractableEntitiesFound;
            interactorModel.OnInteractionStarted += InteractorModel_OnInteractionStarted;
            interactorModel.OnInteractionInProgress += InteractorModel_OnInteractionInProgress;
            interactorModel.OnInteractionFinished += InteractorModel_OnInteractionFinished;
        }

        private void Deinit()
        {
            interactorView.OnInteractInputUpdated -= InteractabilityView_OnInteractInputUpdated;
            interactorView.OnInteractableEntitiesFound -= InteractabilityView_OnInteractableEntitiesFound;
            interactorModel.OnInteractionStarted -= InteractorModel_OnInteractionStarted;
            interactorModel.OnInteractionInProgress -= InteractorModel_OnInteractionInProgress;
            interactorModel.OnInteractionFinished -= InteractorModel_OnInteractionFinished;
        }

        private void InteractabilityView_OnInteractInputUpdated(bool state)
        {
            interactorModel.ToggleInteraction(state);
        }

        private void InteractabilityView_OnInteractableEntitiesFound(List<IInteractable> interactablesEntities)
        {
            if (interactablesEntities is null)
            {
                interactorModel.SetCurrentInteractableEntity(null);
                return;
            }

            Vector2 interactuatorPostion = interactorModel.GetInteractuatorPosition();
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

            interactorModel.SetCurrentInteractableEntity(closestInteractableEntity);
        }

        private void InteractorModel_OnInteractionStarted()
        {
            interactorView.ShowInteractionProgressBar();
        }        

        private void InteractorModel_OnInteractionInProgress(float normalizedValue)
        {
            interactorView.UpdateInteractionProgressBar(normalizedValue);
        }

        private void InteractorModel_OnInteractionFinished()
        {
            interactorView.HideInteractionProgressBar();
        }

    }
}
