using Catalog.Core.Domain.Enums;
using Catalog.Core.Domain.ValueObjects;

namespace Catalog.Core.Domain.Entities
{
    public class Product : Entity
    {
        public Product()
        {
                
        }

        public Product(Category category, string name, decimal price, Stock stock)
        {
            Category = category;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Category Category { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Stock Stock { get; private set; }
        
        public bool HasStock(int quantity)
        {
            return Stock.Quantity >= quantity;
        }

        public void RemoveStock(int quantity)
        {
            Stock.RemoveStock(quantity);
        }

        public void AddStock(int quantity)
        {
            Stock.AddStock(quantity);
        }

        public void Update(Category category, string name, decimal price)
        {
            Category = category;
            Name = name;
            Price = price;
        }
    }
}
