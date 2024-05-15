namespace Gameplay.Systems.ShopSystem.Common
{
    public class ShopSlot 
    {
        private Item currentItem;
        private int itemAmount;

        public Item CurrentItem => currentItem;
        public int ItemAmount => itemAmount;

        public InventorySlot()
        {
            currentItem = null;
            itemAmount = 0;
        }

        public void SetCurrentItem(Item item, int itemAmount = 1)
        {
            currentItem = item;
            this.itemAmount = itemAmount;
        }

        public bool TryToStackItem(Item item, int itemAmount)
        {
            if (currentItem is not IStackable)
            {
                return false;
            }

            if ((currentItem as IStackable).GetMaxStackAmount() < this.itemAmount + itemAmount)
            {
                return false;
            }

            this.itemAmount += itemAmount;
            return true;
        }
    }
}