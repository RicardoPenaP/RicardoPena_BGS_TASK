using Gameplay.Items;

namespace Gameplay.Systems.ShopSystem.Common
{
    public class ShopSlot 
    {
        private Item currentItem;       

        public Item CurrentItem => currentItem;
        

        public ShopSlot()
        {
            currentItem = null;           
        }

        public void SetCurrentItem(Item item)
        {
            currentItem = item;            
        }

    }
}