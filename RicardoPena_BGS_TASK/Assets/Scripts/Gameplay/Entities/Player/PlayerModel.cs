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

        private void Update()
        {            
            UpdatePlayerState();
        }

        private void FixedUpdate()
        {
            UpdatePlayerMovement();
        }

        private void Init()
        {
            SetPlayerState(PlayerState.Idle);
        }

        private void UpdatePlayerState()
        {
            switch (currentState)
            {
                case PlayerState.None:
                    break;
                case PlayerState.Idle:
                    UpdateIdleState();
                    break;
                case PlayerState.Walking:
                    UpdateWalkingState();
                    break;
                case PlayerState.Running:
                    UpdateRunningState();
                    break;
                case PlayerState.Interacting:
                    UpdateInteractingState();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePlayerMovement()
        {
            if (movementDirection.Equals(Vector2.zero))
            {                
                return;
            }
            Move();
        }

        public void MoveTowards(Vector2 movementDirection)
        {
            this.movementDirection = movementDirection;            
        }

        public void StopMovement()
        {
            movementDirection = Vector2.zero;            
            Move();
        }

        public void SetIsRunning(bool state)
        {
            isRunning = state;            
        }

        private void Move()
        {
            if (isRunning)
            {
                playerRigidbody.velocity = movementDirection * movementSettings.RunningSpeed;
            }
            else
            {
                playerRigidbody.velocity = movementDirection * movementSettings.WalkingSpeed;
            }
        }

        public void SetPlayerState(PlayerState state)
        {
            currentState = state;
            OnCurrentStateChange?.Invoke(currentState);
        }

        private void UpdateIdleState()
        {
            if (playerRigidbody.velocity.magnitude > Mathf.Epsilon)
            {
                if (isRunning)
                {
                    SetPlayerState(PlayerState.Running);
                }
                else
                {
                    SetPlayerState(PlayerState.Walking);
                }
            }
        }

        private void UpdateWalkingState()
        {
            if (playerRigidbody.velocity.magnitude > Mathf.Epsilon)
            {
                if (isRunning)
                {
                    SetPlayerState(PlayerState.Running);
                }
            }
            else
            {
                SetPlayerState(PlayerState.Idle);
            }
        }

        private void UpdateRunningState()
        {
            if (playerRigidbody.velocity.magnitude > Mathf.Epsilon)
            {
                if (!isRunning)
                {
                    SetPlayerState(PlayerState.Walking);
                }
            }
            else
            {
                SetPlayerState(PlayerState.Idle);
            }
        }

        private void UpdateInteractingState()
        {

        }
    }
}