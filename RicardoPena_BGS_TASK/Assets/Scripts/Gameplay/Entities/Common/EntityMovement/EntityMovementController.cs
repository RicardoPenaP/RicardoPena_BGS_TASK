using System;

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

        }

        private void Deinit()
        {

        }

        
    }
}
