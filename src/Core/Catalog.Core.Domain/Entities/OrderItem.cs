namespace Catalog.Core.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Guid idProduct, string name, decimal price, int quantity, Guid idOrder)
        {
            IdProduct = idProduct;
            Name = name;
            Price = price;
            Quantity = quantity;
            IdOrder = idOrder;

            Total = quantity * price;
        }

        public Guid IdProduct { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public Guid IdOrder { get; private set; }
        public virtual Order Order { get; private set; }
    }
}
