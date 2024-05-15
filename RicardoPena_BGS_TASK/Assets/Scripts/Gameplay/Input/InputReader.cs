using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Gameplay.Input.Controls;

namespace Gameplay.Input
{
    [CreateAssetMenu(fileName = "NewInputReader", menuName = "Gameplay/Input/Input Reader")]
    public class InputReader : ScriptableObject, IPlayerActions
    {
        public event Action<bool> OnInteractInputUpdated;
        public event Action<Vector2> OnMoveInputUpdated;
        public event Action<bool> OnRunInputUpdated;
        public event Action OnToggleInventoryInputUpdated;

        private Controls controls;

        private void OnEnable()
        {
            if (controls is not null)
            {
                return;
            }

            controls = new Controls();
            controls.Player.SetCallbacks(this);
            controls.Player.Enable();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {           
            OnInteractInputUpdated?.Invoke(context.ReadValueAsButton());
        }

        public void OnMove(InputAction.CallbackContext context) => OnMoveInputUpdated?.Invoke(context.ReadValue<Vector2>());    

        public void OnRun(InputAction.CallbackContext context)
        {
            OnRunInputUpdated?.Invoke(context.ReadValueAsButton());
        }

        public void OnToggleInventoy(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                OnToggleInventoryInputUpdated?.Invoke();
            }
        }
    }
}