namespace Catalog.Core.Application.Features.Users.Login
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
