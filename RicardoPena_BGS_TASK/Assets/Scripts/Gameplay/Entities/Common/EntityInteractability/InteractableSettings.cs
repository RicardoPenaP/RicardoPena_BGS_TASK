using UnityEngine;

namespace Gameplay.Entities.Common.EntityInteractability
{
    [CreateAssetMenu(fileName = "NewInteractableSettings", menuName = "Gameplay/Entities/Common/EntityInteractability/Interactable Settings")]
    public class InteractableSettings : ScriptableObject
    {
        [Header("Interactable Settings")]
        [SerializeField, Min(0f)] private float interactionTime = 0f;

        public float InteractionTime => interactionTime;
    }
}