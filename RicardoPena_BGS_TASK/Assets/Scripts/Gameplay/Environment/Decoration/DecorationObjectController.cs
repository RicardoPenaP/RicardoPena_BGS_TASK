using Gameplay.Entities.Common.EntityInteractability;
using Gameplay.Items;
using UnityEngine;

namespace Gameplay.Environment.Decoration
{
    public class DecorationObjectController : MonoBehaviour
    {
        [Header("Decoration Object Controller")]
        [Header("References")]
        [SerializeField] private DecorationObjectView decorationObjectView;
        [SerializeField] private DecorationObjectModel decorationObjectModel;

        public void ToggleInteractionText(bool state) => decorationObjectView.ToggleInteractionText(state);
        public InteractableSettings GetSettings() => decorationObjectModel.GetSettings();
        public Item GetInteractionReward() => decorationObjectModel.GetInteractionReward();
        public int GetRewardAmount() => decorationObjectModel.GetRewardAmount();
    }
}
