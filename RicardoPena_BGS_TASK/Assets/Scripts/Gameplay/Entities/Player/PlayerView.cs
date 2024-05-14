using Gameplay.Entities.Common.EntityInteractability;
using Gameplay.Entities.Common.EntityMovement;
using Gameplay.Input;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerView : MonoBehaviour, IEntityMovementView, IInteractabilityView
    {
        private const string StateAnimatorParameterName = "State";

        [Header("Player View")]
        [Header("References")]
        [SerializeField] private InputReader inputReader;
        [SerializeField] private Transform spriteRendererTransform;
        [SerializeField] private Animator playerAnimator;

        [Header("Settings")]
        [SerializeField] private float searchDistanceForInteractableEntities = 6f;

        public event Action<Vector2> OnMoveInputDetected;
        public event Action<bool> OnRunInputDetected;
        public event Action<bool> OnInteractInputUpdated;
        public event Action<List<IInteractable>> OnInteractableEntitiesFound;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, searchDistanceForInteractableEntities);
        }

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            SearchInteractableEntities();
        }

        private void OnDestroy()
        {
            Deinit();
        }

        private void Init()
        {
            inputReader.OnMoveInputUpdated += InputReader_OnMoveInputUpdated;
            inputReader.OnRunInputUpdated += InputReader_OnRunInputUpdated;
            inputReader.OnInteractInputUpdated += InputReader_OnInteractInputUpdated;
        }

        private void Deinit()
        {
            inputReader.OnMoveInputUpdated -= InputReader_OnMoveInputUpdated;
            inputReader.OnRunInputUpdated -= InputReader_OnRunInputUpdated;
            inputReader.OnInteractInputUpdated -= InputReader_OnInteractInputUpdated;
        }

        //Events subscription
        private void InputReader_OnMoveInputUpdated(Vector2 rawInput)
        {
            SetLookingDirection(rawInput.x);
            OnMoveInputDetected?.Invoke(rawInput);
        }

        private void InputReader_OnRunInputUpdated(bool state) => OnRunInputDetected?.Invoke(state);

        private void InputReader_OnInteractInputUpdated(bool state)
        {
            OnInteractInputUpdated?.Invoke(state);
        }

        //Movement logic
        private void SetLookingDirection(float direction)
        {
            if (Mathf.Abs(direction) <= Mathf.Epsilon)
            {
                return;
            }

            float normalizedDirection = direction > Mathf.Epsilon ? 1f : -1f;

            if (spriteRendererTransform.localScale.x.Equals(normalizedDirection))
            {
                return;
            }

            Vector3 newLocalScale = spriteRendererTransform.localScale;
            newLocalScale.x = normalizedDirection;
            spriteRendererTransform.localScale = newLocalScale;
        }

        public void UpdatePlayerAnimatorState(PlayerState currentState)
        {
            playerAnimator.SetInteger(StateAnimatorParameterName, (int)currentState);
        }

        //Interactability logic
        private void SearchInteractableEntities()
        {
            Collider2D[] entities = Physics2D.OverlapCircleAll(transform.position, searchDistanceForInteractableEntities);
            List<IInteractable> interactableEntities = new List<IInteractable>();

            if (entities.Length == 0)
            {
                return;
            }

            foreach (Collider2D entity in entities)
            {
                if (entity.TryGetComponent(out IInteractable interactableEntity))
                {
                    interactableEntities.Add(interactableEntity);
                }                
            }

            if (interactableEntities.Count == 0)
            {
                return;
            }

            OnInteractableEntitiesFound?.Invoke(interactableEntities);
        }
    }
}