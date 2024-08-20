using Catalog.Core.Domain.Entities;
using Catalog.Core.Domain.Enums;

namespace Catalog.Core.Application.Features.Products.FindProduct
{
    public class FindProductResponse
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid IdProduct { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public StockResponse Stock { get; set; }

        public class StockResponse
        {
            public int Quantity { get; set; }
        }
    }

    public static class Converter
    {
        public static FindProductResponse ToResponse(this Product product)
        {
            return new FindProductResponse
            {
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                IdProduct = product.Id,
                Category = product.Category,
                Name = product.Name,
                Value = product.Price,

                Stock = new FindProductResponse.StockResponse
                {
                    Quantity = product.Stock.Quantity
                }
            };
        }
    }
}
