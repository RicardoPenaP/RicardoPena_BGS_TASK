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
        }        

        private void Deinit()
        {
            entityMovementView.OnMoveInputDetected -= EntityMovementView_OnMoveInputDetected;
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
    }
}
