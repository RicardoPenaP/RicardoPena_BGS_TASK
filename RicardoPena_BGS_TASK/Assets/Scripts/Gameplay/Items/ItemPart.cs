using UnityEngine;

namespace Gameplay.Items
{
    [CreateAssetMenu(fileName = "NewItemPart", menuName = "Gameplay/Items/Item Part")]
    public class ItemPart : ScriptableObject
    {
        [Header("Item Part")]
        [Header("References")]
        [SerializeField] private string partId;
        [SerializeField] private Sprite partSprite;

        public string PartId => partId;
        public Sprite PartSprite => partSprite;
    }
}