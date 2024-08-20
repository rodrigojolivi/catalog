using Catalog.Infrastructure.Identity.Models;

namespace Catalog.Core.Application.Features.Users.GetUsers
{
    public class GetUsersResponse
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public static class Converter
    {
        public static IEnumerable<GetUsersResponse> ToResponse(this IEnumerable<User> users)
        {
            return users.Select(x => new GetUsersResponse
            {
                IdUser = new Guid(x.Id),
                Name = x.Name,
                Email = x.Email
            });
        }
    }
}
