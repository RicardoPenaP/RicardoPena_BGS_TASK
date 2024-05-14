using Gameplay.Entities.Common.EntityInteractability;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Environment.Decoration
{
    public class DecorationObject : MonoBehaviour, IInteractable
    {
        public Vector2 GetInteractablePosition()
        {
            return transform.position;
        }

        public void HideInteractabilityFeedback()
        {
            throw new System.NotImplementedException();
        }

        public void ShowInteractabilityFeedback()
        {
            throw new System.NotImplementedException();
        }

        public void Interact()
        {
            //Testing
            Destroy(gameObject);
        }

    }
}
