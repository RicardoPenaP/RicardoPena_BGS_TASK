using Gameplay.Entities.Common.EntityMovement;
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

        public void MoveTowards(Vector2 movementDirection)
        {
            playerRigidbody.velocity = movementDirection * movementSettings.MovementSpeed;
        }

        public void StopMovement()
        {
            MoveTowards(Vector2.zero);
        }
    }
}