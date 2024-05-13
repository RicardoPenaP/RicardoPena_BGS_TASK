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
            inputReader.OnMoveInputUpdated += (rawInput) => OnMoveInputDetected?.Invoke(rawInput);
        }

        private void Deinit()
        {
            inputReader.OnMoveInputUpdated -= (rawInput) => OnMoveInputDetected?.Invoke(rawInput);
        }

    }
}