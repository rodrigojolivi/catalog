using Catalog.Core.Application.Notifications;
using MediatR;

namespace Catalog.Core.Application.Features.Stocks.CreateStock
{
    public class CreateStockCommand : IRequest<Response>
    {
        public Guid IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}
