using Gameplay.Entities.Common.EntityInteractability;
using Gameplay.Entities.Common.EntityMovement;
using Gameplay.Systems.InventorySystem;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Controller")]
        [Header("References")]
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerModel playerModel;

        private EntityMovementController entityMovementController;
        private InteractorController interactabilityController;

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
            playerModel.OnCurrentStateChange += PlayerModel_OnCurrentStateChange;
            playerView.OnToggleInventoryInputUpdated += PlayerView_OnToggleInventoryInputUpdated;
            entityMovementController = new EntityMovementController(playerView, playerModel);
            interactabilityController = new InteractorController(playerView, playerModel);
        }

        private void Deinit()
        {
            playerModel.OnCurrentStateChange -= PlayerModel_OnCurrentStateChange;
            playerView.OnToggleInventoryInputUpdated -= PlayerView_OnToggleInventoryInputUpdated;
            entityMovementController.Dispose();
            interactabilityController.Dispose();
        }

        private void PlayerModel_OnCurrentStateChange(PlayerState currentPlayerState)
        {
            playerView.UpdatePlayerAnimatorState(currentPlayerState);
        }

        private void PlayerView_OnToggleInventoryInputUpdated()
        {
            InventorySystem.Instance.ToggleInventory();
        }

    }
}
