using Gameplay.Entities.Common.EntityInteractability;
using UnityEngine;

namespace Gameplay.Environment.Decoration
{
    public class DecorationObjectModel : MonoBehaviour
    {
        [Header("Decoration Object Model")]
        [Header("References")]
        [Header("Settings")]
        [SerializeField] private InteractableSettings settings;

        public InteractableSettings GetSettings() => settings;
        
    }
}