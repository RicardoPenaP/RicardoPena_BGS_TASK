using Gameplay.Entities.Common.EntityMovement;
using Gameplay.Input;
using System;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerView : MonoBehaviour, IEntityMovementView
    {
        [Header("Player View")]
        [Header("References")]
        [SerializeField] private InputReader inputReader;
        [SerializeField] private Transform spriteRendererTransform;

        public event Action<Vector2> OnMoveInputDetected;

        private void Awake()
        {
            Init();
        }

        private void OnDestroy()
        {
            Deinit();
        }

        private void Init()
        {
            inputReader.OnMoveInputUpdated += InputReader_OnMoveInputUpdated;           
        }

        private void Deinit()
        {
            inputReader.OnMoveInputUpdated -= InputReader_OnMoveInputUpdated;
        }

        private void InputReader_OnMoveInputUpdated(Vector2 rawInput)
        {
            SetLookingDirection(rawInput.x);
            OnMoveInputDetected?.Invoke(rawInput);
        }

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
    }
}