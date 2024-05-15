using Gameplay.Entities.Common.EntityInteractability;
using Gameplay.Items;
using UnityEngine;

namespace Gameplay.Environment.Decoration
{
    public class DecorationObjectModel : MonoBehaviour
    {
        [Header("Decoration Object Model")]
        [Header("References")]
        [SerializeField] private Item interactionReward;
        [SerializeField] private int rewardAmount = 0;

        [Header("Settings")]
        [SerializeField] private InteractableSettings settings;


        public InteractableSettings GetSettings() => settings;
        public Item GetInteractionReward() => interactionReward;
        public int GetRewardAmount() => rewardAmount;
    }
}