using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Enums;
using MediatR;

namespace Catalog.Core.Application.Features.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<Response>
    {
        public CreateProductCommand(Category category, string name, decimal price, int quantity)
        {
            Category = category;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
