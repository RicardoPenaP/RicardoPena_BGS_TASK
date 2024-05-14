using TMPro;
using UnityEngine;

namespace Gameplay.Environment.Decoration
{
    public class DecorationObjectView : MonoBehaviour
    {
        [Header("Decoration View")]
        [Header("Reference")]
        [SerializeField] private TextMeshProUGUI interactionText;

        private void Awake()
        {
            ToggleInteractionText(false);
        }

        public void ToggleInteractionText(bool state)
        {
            interactionText.gameObject.SetActive(state);
        }
    }
}