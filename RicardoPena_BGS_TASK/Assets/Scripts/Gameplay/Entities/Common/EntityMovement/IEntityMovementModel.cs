using System;
using UnityEngine;

namespace Gameplay.Entities.Common.EntityMovement
{
    public interface IEntityMovementModel 
    {       
        public void MoveTowards(Vector2 movementDirection);
        public void StopMovement();
        public void SetIsRunning(bool state);
    }
}