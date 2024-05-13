using Gameplay.Entities.Common.EntityMovement;
using System;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerModel : MonoBehaviour, IEntityMovementModel
    {
        [Header("Player Model")]
        [Header("Settings")]
        [SerializeField] private EntityMovementSettings movementSettings;
        [Header("References")]
        [SerializeField] private Rigidbody2D playerRigidbody;

        private bool isRunning = false;

        public void MoveTowards(Vector2 movementDirection)
        {
            if (isRunning)
            {
                playerRigidbody.velocity = movementDirection * movementSettings.RunningSpeed;
            }
            else
            {
                playerRigidbody.velocity = movementDirection * movementSettings.MovementSpeed;
            }            
        }      

        public void StopMovement()
        {
            MoveTowards(Vector2.zero);
        }

        public void SetIsRunning(bool state)
        {
            isRunning = state;
        }

    }
}