using Catalog.Core.Domain.Entities;
using Catalog.Core.Domain.Enums;
using Catalog.Core.Domain.ValueObjects;

namespace Catalog.Test.Unit
{
    public class ProductTest
    {
        [Fact]
        public void Check_Stock_Return_Success()
        {
            var product = NewProduct();

            Assert.True(product.HasStock(1));
        }

        [Fact]
        public void Add_Stock_Return_Success()
        {
            var product = NewProduct();

            product.AddStock(1);

            Assert.True(product.Stock.Quantity == 101);
        }

        [Fact]
        public void Remove_Stock_Return_Success()
        {
            var product = NewProduct();

            product.RemoveStock(1);

            Assert.True(product.Stock.Quantity == 99);
        }

        [Fact]
        public void Update_Product_Return_Success()
        {
            var product = NewProduct();

            product.Update(Category.Technology, "Desktop", 2500M);

            Assert.True(product.Category == Category.Technology);
            Assert.True(product.Name == "Desktop");
            Assert.True(product.Price == 2500M);
        }

        private Product NewProduct()
        {
            return new Product(Category.Car, "Toyota Corolla", 150.000M, new Stock(100));
        }
    }
}