using Gameplay.Items;
using UnityEngine;

namespace Gameplay.Systems.InventorySystem
{
    public class CosmecticEquiper : MonoBehaviour
    {
        [Header("Comestic Equiper")]
        [Header("References")]
        [SerializeField] private SpriteRenderer armL;
        [SerializeField] private SpriteRenderer armR;
        [SerializeField] private SpriteRenderer finger;
        [SerializeField] private SpriteRenderer forearmL;
        [SerializeField] private SpriteRenderer forearmR;
        [SerializeField] private SpriteRenderer handL;
        [SerializeField] private SpriteRenderer handR;
        [SerializeField] private SpriteRenderer legL;
        [SerializeField] private SpriteRenderer legR;
        [SerializeField] private SpriteRenderer pelvis;
        [SerializeField] private SpriteRenderer shinL;
        [SerializeField] private SpriteRenderer shinR;
        [SerializeField] private SpriteRenderer sleeveR;
        [SerializeField] private SpriteRenderer torso;
        
        public void SetCosmetic(IEquipable equipableItem)
        {
            foreach (ItemPart itemPart in equipableItem.ItemParts)
            {
                SpriteRenderer targetSpriteRenderer = null;
                switch (itemPart.PartId)
                {
                    case "ArmL":
                        targetSpriteRenderer = armL;
                        break;
                    case "ArmR":
                        targetSpriteRenderer = armR;
                        break;
                    case "Finger":
                        targetSpriteRenderer = finger;
                        break;
                    case "ForearmL":
                        targetSpriteRenderer = forearmL;
                        break;
                    case "ForearmR":
                        targetSpriteRenderer = forearmR;
                        break;
                    case "HandL":
                        targetSpriteRenderer = handL;
                        break;
                    case "HandR":
                        targetSpriteRenderer = handR;
                        break;
                    case "Leg":
                        targetSpriteRenderer = legL;
                        targetSpriteRenderer.sprite = itemPart.PartSprite;
                        targetSpriteRenderer = legR;
                        break;
                    case "Pelvis":
                        targetSpriteRenderer = pelvis;
                        break;
                    case "Shin":
                        targetSpriteRenderer = shinL;
                        targetSpriteRenderer.sprite = itemPart.PartSprite;
                        targetSpriteRenderer = shinR; 
                        break;
                    case "SleeveR":
                        targetSpriteRenderer = sleeveR;
                        break;
                    case "Torso":
                        targetSpriteRenderer = torso;
                        break;
                    default:
                        break;
                }

                targetSpriteRenderer.sprite = itemPart.PartSprite;
            }
        }
    }
}
