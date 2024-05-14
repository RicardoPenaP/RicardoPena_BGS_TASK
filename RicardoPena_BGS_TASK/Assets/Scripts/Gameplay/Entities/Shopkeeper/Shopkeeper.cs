using Gameplay.Entities.Common.EntityInteractability;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Entities.Shopkeeper
{
    public class Shopkeeper : MonoBehaviour, IInteractable
    {
        [Header("Shopkeeper")]
        [Header("References")]
        [SerializeField] private ShopkeeperController shopkeeperController;

        public Vector2 GetInteractablePosition()
        {
            return transform.position;
        }

        public void HideInteractabilityFeedback()
        {
            throw new System.NotImplementedException();
        }

        public void Interact()
        {
            throw new System.NotImplementedException();
        }

        public void ShowInteractabilityFeedback()
        {
            throw new System.NotImplementedException();
        }

    }
}
