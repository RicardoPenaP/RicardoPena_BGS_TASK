using Gameplay.Entities.Common.EntityInteractability;
using Gameplay.Entities.Common.EntityMovement;
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
        private InteractabilityController interactabilityController;

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
            entityMovementController = new EntityMovementController(playerView, playerModel);
            interactabilityController = new InteractabilityController(playerView, playerModel);
        }

        private void Deinit()
        {
            entityMovementController.Dispose();
            interactabilityController.Dispose();
        }

        private void PlayerModel_OnCurrentStateChange(PlayerState currentPlayerState)
        {
            playerView.UpdatePlayerAnimatorState(currentPlayerState);
        }
    }
}
