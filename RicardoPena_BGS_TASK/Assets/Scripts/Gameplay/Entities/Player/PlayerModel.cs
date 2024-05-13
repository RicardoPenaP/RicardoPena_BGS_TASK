using Gameplay.Entities.Common.EntityMovement;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerModel : MonoBehaviour, IEntityMovementModel
    {
        [Header("Player Model")]
        [Header("References")]
        [SerializeField] private Rigidbody2D playerRigidbody;

        public void MoveTowards(Vector2 movementDirection)
        {
            playerRigidbody.velocity = movementDirection * 6f;          //Change the value with movement settings value
        }

        public void StopMovement()
        {
            MoveTowards(Vector2.zero);
        }
    }
}