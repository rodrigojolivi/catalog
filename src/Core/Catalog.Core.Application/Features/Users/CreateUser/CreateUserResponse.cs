namespace Catalog.Core.Application.Features.Users.CreateUser
{
    public class CreateUserResponse
    {
        public string Token { get; set; }
    }

    public static class Converter
    {
        public static CreateUserResponse ToResponse(this string token)
        {
            return new CreateUserResponse
            {
                Token = token
            };
        }
    }
}
