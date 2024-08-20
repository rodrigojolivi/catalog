using MediatR;
using Catalog.Core.Application.Notifications;

namespace Catalog.Core.Application.Features.Users.FindUser
{
    public class FindUserQuery : IRequest<Response>
    {
        public Guid? IdUser { get; set; }
    }
}
