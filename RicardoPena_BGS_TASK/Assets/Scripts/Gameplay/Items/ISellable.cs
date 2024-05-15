namespace Gameplay.Items
{
    public interface ISellable 
    {
        public int GetSellPrice();
        public void Sell();
    }
}