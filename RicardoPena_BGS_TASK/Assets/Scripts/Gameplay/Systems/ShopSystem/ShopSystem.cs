using UnityEngine;

namespace Gameplay.Systems.ShopSystem
{
    public class ShopSystem : MonoBehaviour
    {
        private static ShopSystem instance;
        public static ShopSystem Instance => instance;

        [Header("Inventory System")]
        [Header("References")]
        [SerializeField] private GameObject inventoryController;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            if (instance is not null && !instance.Equals(this))
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }
    }
}
