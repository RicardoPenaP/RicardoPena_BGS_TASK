using UnityEngine;

namespace Gameplay.Entities.Common.EntityMovement
{
    [CreateAssetMenu(fileName = "NewEntityMovementSettings", menuName = "Gameplay/Entities/Common/EntityMovement/Entity Movement Settings")]
    public class EntityMovementSettings : ScriptableObject
    {
        [Header("Entity Movement Settings")]
        [SerializeField] private float walkingSpeed = 6f;
        [SerializeField, Range(1f, 10f)] private float runningSpeedMultiplier = 1.5f;

        public float WalkingSpeed => walkingSpeed;
        public float RunningSpeed => walkingSpeed * runningSpeedMultiplier;
    }
}