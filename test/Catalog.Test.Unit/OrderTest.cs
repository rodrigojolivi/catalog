using Catalog.Core.Domain.Entities;

namespace Catalog.Test.Unit
{
    public class OrderTest
    {
        [Fact]
        public void Create_Order_Return_Success()
        {
            var order = NewOrder();

            Assert.True(order.IdCustomer != Guid.Empty);
            Assert.True(order.Date.Date == DateTime.Now.Date);
            Assert.True(!string.IsNullOrWhiteSpace(order.Code));
        }

        [Fact]
        public void Set_Value_Order_Return_Success()
        {
            var order = NewOrder();

            order.SetValue(10, 100.00M);

            Assert.True(order.Value == 1000);
        }

        [Fact]
        public void Add_Order_Item_Return_Success()
        {
            var order = NewOrder();

            order.AddOrderItem(new OrderItem(Guid.NewGuid(), "Desktop", 2000.00M, 2, order.Id));
            order.AddOrderItem(new OrderItem(Guid.NewGuid(), "Teclado", 150.00M, 2, order.Id));

            Assert.True(order.OrderItems.Count == 2);
        }

        private Order NewOrder()
        {
            return new Order(Guid.NewGuid());
        }
    }
}
