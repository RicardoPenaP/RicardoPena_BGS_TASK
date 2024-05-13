using System;
using UnityEngine;

namespace Gameplay.Entities.Common.EntityMovement
{
    public class EntityMovementController  : IDisposable
    {
        private readonly IEntityMovementView entityMovementView;
        private readonly IEntityMovementModel entityMovementModel;

        public EntityMovementController(IEntityMovementView entityMovementView, IEntityMovementModel entityMovementModel)
        {
            this.entityMovementView = entityMovementView;
            this.entityMovementModel = entityMovementModel;
            Init();
        }

        public void Dispose()
        {
            Deinit();
        }

        private void Init()
        {
            entityMovementView.OnMoveInputDetected += EntityMovementView_OnMoveInputDetected;
            entityMovementView.OnRunInputDetected += EntityMovementView_OnRunInputDetected;
        }       

        private void Deinit()
        {
            entityMovementView.OnMoveInputDetected -= EntityMovementView_OnMoveInputDetected;
            entityMovementView.OnRunInputDetected -= EntityMovementView_OnRunInputDetected;
        }

        private void EntityMovementView_OnMoveInputDetected(Vector2 rawMovementDirection)
        {
            if (rawMovementDirection.magnitude > Mathf.Epsilon)
            {
                entityMovementModel.MoveTowards(rawMovementDirection);
            }
            else
            {
                entityMovementModel.StopMovement();
            }            
        }

        private void EntityMovementView_OnRunInputDetected(bool state) => entityMovementModel.SetIsRunning(state);

    }
}
