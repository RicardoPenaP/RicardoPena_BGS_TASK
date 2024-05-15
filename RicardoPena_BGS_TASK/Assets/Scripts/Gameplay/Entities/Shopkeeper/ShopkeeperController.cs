using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class ShopkeeperController : MonoBehaviour
    {
        [Header("Shopkeeper Controller")]
        [Header("References")]
        [SerializeField] private ShopkeeperView shopkeeperView;
        [SerializeField] private ShopkeeperModel shopkeeperModel;

        public void ToggleInteractionText(bool state) => shopkeeperView.ToggleInteractionText(state);

        public void Interact()
        {

        }
    }
}
