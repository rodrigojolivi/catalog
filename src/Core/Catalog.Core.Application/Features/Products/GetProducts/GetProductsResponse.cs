using Catalog.Core.Domain.Entities;
using Catalog.Core.Domain.Enums;

namespace Catalog.Core.Application.Features.Products.GetProducts
{
    public class GetProductsResponse
    {
        public Guid IdProduct { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }

    public static class Converter
    {
        public static IEnumerable<GetProductsResponse> ToResponse(this IQueryable<Product> products)
        {
            return products.Select(x => new GetProductsResponse
            {
                IdProduct = x.Id,
                Category = x.Category,
                Name = x.Name,
                Value = x.Price
            });
        }
    }
}
