using UnityEngine;

namespace Gameplay.Entities.Common.EntityMovement
{
    [CreateAssetMenu(fileName = "NewEntityMovementSettings", menuName = "Gameplay/Entities/Common/EntityMovement/Entity Movement Settings")]
    public class EntityMovementSettings : ScriptableObject
    {
        [Header("Entity Movement Settings")]
        [SerializeField] private float movementSpeed = 6f;

        public float MovementSpeed => movementSpeed;
    }
}