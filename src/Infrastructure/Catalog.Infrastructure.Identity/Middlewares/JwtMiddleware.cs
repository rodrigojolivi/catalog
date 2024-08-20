using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Catalog.Infrastructure.Identity.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();

                var jwtSecurityToken = handler.ReadJwtToken(token);

                context.Items["email"] = jwtSecurityToken.Claims.First(x => x.Type == "email").Value;
            }

            await _next(context);
        }
    }
}
