namespace Catalog.Infrastructure.Identity.Tokens
{
    public interface ITokenService
    {
        string GenerateToken(string name, string email, IEnumerable<string> roles);
    }
}
