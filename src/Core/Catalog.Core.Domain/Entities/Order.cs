namespace Catalog.Core.Domain.Entities
{
    public class Order : Entity
    {
        public Order(Guid idCustomer)
        {
            IdCustomer = idCustomer;

            Date = DateTime.Now;
            Code = Guid.NewGuid().ToString().Replace("-", "");

            OrderItems = [];
        }

        public DateTime Date { get; private set; }
        public string Code { get; private set; }
        public decimal Value { get; private set; }
        public Guid IdCustomer { get; private set; }
        public virtual IList<OrderItem> OrderItems { get; private set; }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public void SetValue(int quantity, decimal unitValue)
        {
            Value += quantity * unitValue;
        }
    }
}
