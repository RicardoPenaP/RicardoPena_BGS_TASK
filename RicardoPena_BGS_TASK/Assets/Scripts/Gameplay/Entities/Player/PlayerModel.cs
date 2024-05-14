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

        public event Action<PlayerState> OnCurrentStateChange;

        private PlayerState currentState = PlayerState.None;

        private bool isRunning = false;
        private Vector2 movementDirection;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            SetPlayerState(PlayerState.Idle);
        }

        public void SetPlayerState(PlayerState state)
        {
            currentState = state;
            OnCurrentStateChange?.Invoke(currentState);
        }

        public void MoveTowards(Vector2 movementDirection)
        {
            this.movementDirection = movementDirection;
            Move();
        }      

        public void StopMovement()
        {
            this.movementDirection = Vector2.zero;
            Move();
        }

        public void SetIsRunning(bool state)
        {
            isRunning = state;
            Move();
        }

        private void Move()
        {
            if (isRunning)
            {
                playerRigidbody.velocity = movementDirection * movementSettings.RunningSpeed;
                SetPlayerState(PlayerState.Running);
            }
            else
            {
                playerRigidbody.velocity = movementDirection * movementSettings.WalkingSpeed;
                SetPlayerState(PlayerState.Walking);
            }
        }


    }
}