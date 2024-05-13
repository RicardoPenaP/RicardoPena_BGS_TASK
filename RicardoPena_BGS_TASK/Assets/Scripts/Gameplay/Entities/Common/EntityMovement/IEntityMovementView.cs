using System;
using UnityEngine;

namespace Gameplay.Entities.Common.EntityMovement
{
    public interface IEntityMovementView 
    {
        public event Action<Vector2> OnMoveInputDetected;
        public event Action<bool> OnRunInputDetected;
    }
}