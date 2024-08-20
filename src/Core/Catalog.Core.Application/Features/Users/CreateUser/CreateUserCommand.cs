using Catalog.Core.Application.Notifications;
using MediatR;

namespace Catalog.Core.Application.Features.Users.CreateUser
{
    public class CreateUserCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
