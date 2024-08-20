using Catalog.Infrastructure.Identity.Models;

namespace Catalog.Core.Application.Features.Users.FindUser
{
    public class FindUserResponse
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid IdCompany { get; set; }
    }

    public static class Converter
    {
        public static FindUserResponse ToResponse(this User user)
        {
            return new FindUserResponse
            {
                IdUser = new Guid(user.Id),
                Name = user.Name,
                Phone = user.PhoneNumber,
                Email = user.Email
            };
        }
    }
}
