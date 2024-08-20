namespace Catalog.Core.Domain.ValueObjects
{
    public class Stock
    {
        public Stock(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }

        public void AddStock(int quantity)
        {
            Quantity += quantity;
        }

        public void RemoveStock(int quantity)
        {
            Quantity -= quantity;
        }
    }
}
