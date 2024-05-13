using UnityEngine;

namespace Gameplay.Entities.Common.EntityMovement
{
    public interface IEntityMovementModel 
    {
        public void MoveTowards(Vector2 movementDirection);
    }
}